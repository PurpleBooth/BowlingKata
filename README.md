# The Bowling Kata

I wanted to demo some unit tests in C# for a friend. I did this using the bowling Kata

## Rules 

The the bowling kata is:

Create a class with 2 methods:
 - roll(self, pins)
 - score(self)

The rules for scoring are as follows
* A game is 10 frames
* Each frame can have up to 2 rolls
* A spare is when you knock down all pins in a frame
* A strike is when you knock down all pins in the first roll of a frame
* The score for a frame is the number of pins knocked down
* If a spare is scored, the next roll is added as a bonus
* If a strike is scored, the next 2 rolls are added as a bonus
* A perfect game is 12 successive strikes and score 300 points
