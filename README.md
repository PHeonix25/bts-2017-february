# Behind the Scenes - 2017.02 - Utilising Elastic Stack in .Net development

> At Coolblue, we use the ELK stack (now Elastic stack) to collect and analyse errors across the whole company. Unfortunately (for us .Net back-office guys at least), integration isn't as simple as we'd hoped. Join us for this session where Pat will go through how we integrate with the Elastic Stack - from Development all the way to Production, and Nathan will demonstrate refactoring some of our existing applications to support this new requirement using the Mikado method.

# Using the Elastic Stack as a .Net developer

> In this talk, Pat will step us through how we integrate with the Elastic Stack here at Coolblue, using tooling like Log4Net, Serilog, Seq and Redis. Along the way, we'll get introduced to the role of each of these technologies, and as an added bonus, Pat will demo how we can set some of these tools up in Docker containers in order to aid our rapid development and testing feedback cycles.

# Slides?

Yup, in progress [over here](https://docs.google.com/a/coolblue.eu/presentation/d/1LjQmKwLs92IcK-U7FDlWf6f-r-9x0fFT88sf4UcV7KM/edit?usp=sharing). Let me know if you have any feedback [via Slack](https://coolblue.slack.com/messages/@p.hermens/).

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

> Redis is too fast in Prod, so we'll slow it down to demo it  (just don't turn on LogStash yet)

### Standardisation
> Ugly screenshot

> Good screenshot 

> Why? - Many apps sending to the same cluster, and we want to very quickly narrow down what's going wrong, and we want to have separate indexes per application for ease of searching/diagnostics. Apps can have different security requirements for pruning.

## Working demo of Elastic stack in Docker for local confirmation
    DEMO
      - Set up Docker images of Redis + Elastic Stack
      - Add UDPAppender[1] to shoot messages to Redis 
      - Demo the messages arriving in ELK

## What about monitoring?
> What good is all this logging without monitoring?

> Mention it, but it's not the focus!

## Take-homes?
> Docker images for Seq, Redis, ELK

> Understanding the importance of logging

> Learning how to connect .Net apps & ELK via Redis

[1] http://www.s2-industries.com/wordpress/2014/08/logstash-configuration-tips-for-windows-log4net-configuration