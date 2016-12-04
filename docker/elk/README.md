## What is this?

This is a `docker-compose`-compatible repo that will launch Redis, Redis-Commander (a nice GUI for Redis) and the ELK Stack across 3 containers; 
designed for intercepting, manipulating, and loading flat strings sent over UDP by Log4Net.

## What does it run?

Running `docker-compose up` will build (if not already built) and launch three containers:

1. Redis (using the standard `redis` image, running on port `6379`)
2. Redis Commander (using the `tenstartups/redis-commander` image, running on port `8081`)
3. The ELK Stack (using our homegrown image, based off the `sebp/elk` image, running on ports `5000`, `5044`, `5601`, `9200` and `9300`)

The image creation commands for container #3 can be found in the local [Dockerfile](Dockerfile).

## How to get started

> _NOTE to **Docker on Windows** people: Make sure you're using **Linux containers**!_

It's nice and simple, just run `docker-compose up -d` and you're done.

For the purposes of debugging, you can leave off the `-d` and just use `docker-compose up` to check the streaming logs for errors. 
These apps do log very well by default, so read carefully!

## Cool, how can I use it?

1. Send data to Redis at `localhost:6379` (in our demo we'll use a Log4Net UDP Appender)
2. Open the Kibana interface at `http://localhost:5601/`
3. Create an index in Kibana named `log4net_app-*`

> _NOTE: If you've changed the config files (specifically, [30-output.conf](configs/30-output.conf), then you'll need to change the value for the index in Step 3)_

## Checking the results

Apart from using `docker ps -a` to check on the state of the containers, you can use the following URL's to play with the tools:

First check Redis using [RedisCommander](http://localhost:8081/) (at `http://localhost:8081/`) - 
if your messages are stuck here, then you have a problem with your configuration keys; see [03-redis.conf](configs/03-redis.conf)

Then check [ElasticSearch](http://localhost:9200/_search?pretty) (using `http://localhost:9200/_search?pretty`) - if your messages are showing up here correctly, then you're doing OK. 
Check the formatting in the JSON (make sure there's no weird `%{@metadata/_index}` keys or anything)
Also take note of the `_index` value - that needs to match your Kibana filter!

If your messages aren't in the ElasticSearch search above, there's not a lot of debugging/help available between Redis and ElasticSearch
So if you've sent corrupt documents, or misconfigured the `conf` files, you'll need to keep an eye on the messages thrown from the docker images themselves!
Running `docker-compose up` (i.e.: without the `-d`) will help you find the error messages you need to Google.
Once everything is running smoothly, you should be able to see the documents appearing in the [ElasticSearch search results](http://localhost:9200/_search?pretty).

Finally, when you first load [Kibana](http://localhost:5601/) (at `http://localhost:5601/`), you'll get asked to provide a "default" key. This should match your `_index` values in your messages.
Best design is to use something like `log4net_app-*` if you're using our example configurations.
You will definitely need to set this yourself though!

If you got this far, then you should have everything you need in Kibana, so happy `Discover`-ing. 
 
## ...and thanks!

I've used quite a few tools to set all this up and confirm the behaviour along the way! 

I've tried to keep track of most of them so that you don't have to have your Google-fu at full power when you start modifying this and get stuck, so here they are, loosely grouped by category:

### Log4Net UDPAppender debugging
* [Sentinel](https://sentinel.codeplex.com/) - you do need to update your logging pattern though! Read their README!~

### Log4Net RedisAppender (*for when you give up debugging the UDPAppender*)
* [govin's RedisAppender: Redis4Net](https://github.com/govin/redis4net/)

### LogStash Reference Guides
* [The official docs are great](https://www.elastic.co/guide/en/logstash/current/index.html)

### LogStash `Grok`-ing 
* [Allowed grok patterns](https://github.com/logstash-plugins/logstash-patterns-core/blob/master/patterns/grok-patterns)
* [LogStash grok tester](http://grokconstructor.appspot.com/do/match)

### Special mentions:
* [MattHodge](https://twitter.com/matthodge) for being my "rubber duck" on a Sunday night when I couldn't get this all working properly and was [missing a single Dockerfile command](Dockerfile#L8)!
* The BtS crew that helped me prep the presentation and were patient while I worked out all the kinks.
* My wife, for understanding why I was screaming at configuration files late into the night.