void write(string motorName, int force, int mult, double anguloAlvo)
{
    // Cria o objeto do motor:
    Servomotor motor = Bot.GetComponent<Servomotor>(motorName);
    motor.Locked = false;
    // Declarar constantes PID:
    // Ajuste para melhorar a precisão
    const double kp = 1.4;
    const double ki = 0.01;
    const double kd = 0.01;
    // Variáveis de controle:
    double erro = 0, P = 0, I = 0, D = 0, PID = 0, erroAnterior = 0;
    double anguloAtual = 0;
    double caminho1 = 0, caminho2 = 0;

    // Calula o menor erro:
    anguloAtual = Utils.Map(motor.Angle, -180, 180, 0, 360);
    caminho1 = Math.Abs(anguloAlvo - anguloAtual);
    caminho2 = Math.Abs(Math.Abs(anguloAlvo - anguloAtual) - 360);
    if (caminho1 < caminho2)
    {
        if (anguloAtual < anguloAlvo)
        {
            erro = caminho1;
        }
        else
        {
            erro = -caminho1;
        }
    }
    else if (caminho1 > caminho2)
    {
        if (anguloAtual < anguloAlvo)
        {
            erro = -caminho2;
        }
        else
        {
            erro = caminho2;
        }
    }

    if (erro == 0) { I = 0; }
    P = erro;
    I = I + erro;
    D = erro - erroAnterior;
    PID = (kp * P) + (ki * I) + (kd * D);
    erroAnterior = erro;

    motor.Apply(force, PID * mult);
}

async Task Main()
{
    // Variáveis
    int force = 20;
    int mult = 1;
    int vel = 100;

    while (true)
    {
        await Time.Delay(1);

        while (true)
        {
            await Time.Delay(1);

            // Positions the motor called "motor" at an angle of 80°
            write("motor", force, mult, 80);
        }
    }
}
