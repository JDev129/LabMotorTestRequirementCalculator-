# LabMotorTestRequirementCalculator-
Calculates the lab test required for electric motors.  


Imagine you’re at work. A lab test engineer comes into your office and says, ‘Bob, I need your help solving a puzzle.’ He presents you with a spreadsheet; an excel file. He calls it ‘the matrix’. You’re intrigued.  In it contains a long list of varying combinations of different motor characteristics like speed, voltage, phase, frequency, and many others, combined with various types of UL certified motor test, such as performance test, timed heat run, DDF’s and LR Single and LR Three phase (22 different types of test in total), all in a 300+ line excel grid. He explains how the lab engineer had to vertically scroll through the various combinations of motor characteristics values (the different spreadsheet lines) until he or she finds which line represented the motor he needed to test. Then they would horizontally scroll through the line to copy down which test had to be performed on that particular motor. Although the task was not overly difficult it was unnecessarily time consuming and particularly vulnerable to human error. You had just been given the new Software Developer position at your companies engineering division and promptly offer your help.  

![alt text](https://github.com/JDev129/LabMotorTestRequirementCalculator-/blob/master/Matrix.PNG)



Now the question becomes, what route do you take to answer the question. How do you solve ‘the matrix’? Something like the following did get presented to me a number of years ago. I used a tool I had only recently been introduced to, C#. Although this is not at all the solution I came up with at the time the following should always give you the correct result for the motor you input. The excel file needed to understand the solution to the algorith is defined in the spreadsheet named 'Lab Testing Rules.xlsx' contained inside the documentation folder inside the domain of the ULLabCertification library. This file is key to understanding the premise of the project.

Since the original solution, I have grown in my understanding of the C# language and attempted to improve the original version so it was easier to read and understand. However, the solution to the algorithm is the same, that which would tell the lab tester which test to run. The heart can be found in the class ‘TestCalculation.cs’ and function ‘RequiredTest’ which returns an IEnumerable of IMotorTest. Although this particular function might not look overly difficult, understanding which combinations of characteristics give rise to which test had taken me a great deal of time and study and even trial and error to determine.  

 Also, as a fun exercise I’ve also added a .NET console application 'LabMotorTest' which relys on the library 'ConsoleInterpreter' as the user interface for retrieving the required parameters for the calculation and displaying the results. Although obviously a web interface is a more logical choice, I’ll leave that piece for you. Take a look at the class ConsolePromptValidation.cs inside this library. In it I force the console input to pass the validation function provided in the implementation of the IConsoleInputValidator.cs interface given to the constructor of ConsolePromptValidation.cs. Essentially this object places unending console.Read()'s on the console until the user provides a valid value defined by the creator of the implementation of the interface. It then becomes the callers' responsibility to properly communicate the possible valid options to the end user inside of the imputPrompt getter property defined on corresponding class implementing the IConsoleInputValidator.cs interface.

Take a look, try it out, make a branch, see if you can make any sense of it. Let me know if you have any questions or input.

Thanks,
Jeremy Christman
Jchristman129@gmail.com
