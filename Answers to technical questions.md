# Technical questions

 1.  How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add.
 
> I've spent about a day. I had enought time but if I would want to make it more complete, I would add more tests

 2. What was the most useful feature that was added to the latest version of your language of choice? Please include a snippet of code that shows how you've used it.
 > I think interface defaultimplementationis quite usefull
 > I've used that tocreate an interface that can handle mapping in automapper properly
 
```c#
public interface IMapFrom<T>
where T : class
{
    protected void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
```
3.  How would you track down a performance issue in production? Have you ever had to do this? 
 > I would use application monitoring systems e.g. Azure AppInsights, Elasticsearch APM. and yes I've used them for a long time and implemented a one as well
 
4. What was the latest technical book you have read or tech conference you have been to? What did you learn?

> I've read .NET Microservices Architecture for Containerized .NET Applications and attended ng-conf (virtually for sure)
> I learned so many about architecture best practices, tools and avoidances 

5. What do you think about this technical assessment?
> Indeed it was quite good. I feel good to know someone will judge my work not my talkings 

6. Please, describe yourself using JSON.
```json
{
  "name": "Mahdi",
  "last-name": "Abdolvahab",
  "email": "m.abdolvahab@gmail.com"
}
```
