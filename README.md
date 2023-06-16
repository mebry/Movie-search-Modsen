Project Topic - Kinopoisk

Overall application architecture: Microservice-based

Each service is implemented using the N-Layer architecture

Technologies Used:
1. FluentValidation
2. Entity Framework + Fluent API
3. ASP.Net Core Web Api
4. RabbitMQ
5. MS SQLServer
6. AutoMapper, Mapster
7. Docker
8. IdentityServer4
9. Ocelot Gateway

Project Description:

1. Viewing film information, including genres, age restrictions, and ratings.
2. Pagination of films, filtering, and sorting based on different parameters passed as parameters.
3. Tracking sequels and prequels.
4. Working with staff for films.
5. Film rating.
6. Ability to add reviews.
7. Film collections.
8. Authorization and authentication.
9. Role-based policy.
10. Statistics.
11. Ability to create new films, edit and delete.
12. Ability to modify or remove ratings as per user discretion.
13. Ability to add new staff and edit their information.

Microservices:

1. Films
2. Collections
3. Reviews
4. Ratings
5. Employees
6. Statistics
7. Authorization

Simplified version of databases for microservices. 
Statistics is not shown in this diagram. 
Also, not all replication for databases is provided.
Countries is an enumeration stored in Shared.
![image](https://github.com/mebry/Movie-search-Modsen/assets/91991278/d74ade6b-16e6-4769-91a1-42f98528d97a)

