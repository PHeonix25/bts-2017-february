# Behind the Scenes - 2016.12

> At Coolblue, we use the ELK stack (now Elastic stack) to SOMETHING SOMETHING all across the company. Unfortunately (for us .Net back-office guys at least), integration isn't as simple as we'd hoped. Join us for this session where Pat will go through how we integrate with the Elastic Stack - from Development all the way to Production, and Nathan will demonstrate refactoring some of our existing applications to support this new requirement using the Mikado method.

# Using the Elastic Stack as a .Net developer

> In this talk, Pat will step us through how we integrate with the Elastic Stack here at Coolblue, using tooling like Log4Net, Seq, Serilog and Redis. Along the way, we'll get introduced to the role of each of these technologies, and as an added bonus, Pat will demo how we can set some of these tools up in Docker containers in order to aid the rapid development and testing feedback cycles that we value here at Coolblue.

# Talk Notes:

## What is Elastic Stack (Elk Stack)
> Write up of the purpose of the stack, as well as it's different pieces.

## Why do we use it?
> Importance of logging in a fail-fast environment.

### Log4Net
> "Legacy apps" - lowest common denominator. Tried and tested.

## Working demo of Log4Net 
    DEMO
      - Brand new console app
      - Add Log4Net and basic appenders
      - Drop messages to local file

## More tooling?
> Log4Net just isn't enough by itself...

### Seq in Docker
> Lets get Seq set up in a local Docker container and add our appender

## Working demo of Dockerised Seq 
    DEMO
      - Ramp up Docker image of Seq
      - Add Seq appender to console app
      - Log some more messages
      - Show the (development) value in Seq

### Serilog
> Maybe we can swap out for a better logging framework instead of requiring Seq?

> Describe Serilog, to set it up for Nathan (mention his talk)

## And for Production?
> How does this differ across DTAP environments

### Redis
> Anonymised screenshots from #Skynet

### Standardisation
> Ugly screenshot

> Good screenshot 

## Working demo of Elastic stack in Docker for local confirmation
    DEMO
      - Set up Docker images of Redis + Elastic Stack
      - Add [UDPAppender][1] to shoot messages to Redis 
      - Demo the messages arriving in ELK

## What about monitoring?
> What good is all this logging without monitoring?

> Mention it, but it's not the focus!

## Take-homes?
> Docker images for Seq, Redis, ELK - at `/coolblue-development` or `/phermens`?

> Understanding the importance of logging

> Learning how to connect .Net apps & ELK via Redis

[1]: http://www.s2-industries.com/wordpress/2014/08/logstash-configuration-tips-for-windows-log4net-configuration