# Rabbits (^_^)

Pre-reqs :

RabbitMQ, .NET and VS (built with 2015)

Outline :

This example has a producer and a consumer that communicate via a mostly default rabbit queue.
The producer JSONifies an Item POCO and sends it as a byte array to the queue, together with the POCOs type in the message's metadata.
The consumer receives the message together with the type metadata, deserialises the type into type object, which is then passed on to a strategy pattern mechanism (ItemProcessorFactory) which works out the appropriate concrete ItemProcessor and processes the object accordingly.
