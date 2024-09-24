# Servomotors in sBotics
A function written in C# to use the sBotics platform servomotors in a similar way to an Arduino servomotor, making it possible to keep the motor stable at a specific angle between 0 and 360°.
# How to use
```write("motor", force, mult, ang);```
<br/>
motor ->  name of the motor component used (string);
<br/>
force ->  engine strength (int);
<br/>
mult  ->  speed multiplier, used to make the motor faster, but very high values ​​can cause problems with PID control (int);
<br/>
ang   ->  angle you want the motor to position itself at (double).
<br/>
# Possible problems and how to solve them
1. "the engine keeps spinning instead of stopping in the desired position" -> try to reduce the value of the multiplier entered as a function parameter;
2. "the engine does not move" -> if the motor is being used to lift a claw or other part of the robot, the force reported as a function parameter may be insufficient, try increasing the force.
