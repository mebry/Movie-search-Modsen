Microservice for working with films.

Added a data access layer. Developed a database with replication of necessary data. Created extension methods for pagination, including data in a movie, filtering by string, and sorting by string with the ability to choose sorting directions. Sorting and filtering allow operations on multiple parameters without explicitly specifying sorting fields in the code. This is achieved using the System.Linq.Dynamic.Core library. Implemented model configurations. Added indexes for movies. Implemented repositories.

Added a layer for handling business logic. Added 2 types of DTOs. The first ones are used for creating and updating DTOs, and they are slightly trimmed down as they don't contain an Id. The second type of DTO is used for data retrieval and is utilized during data creation and retrieval.
Validators have been added for the first type of DTO. Services and dependency injection (DI) have been added. Several extension methods have been added:

1. Enum conversion for retrieving the country name.
2. Retrieval of all errors in a stylized format for ValidationErrors.
3. An extension method for binding interfaces and their implementations.

API versioning will be added, as well as the layer responsible for the API itself.

A database schema with replication.
![image](https://github.com/mebry/Movie-search-Modsen/assets/98938779/c6b7a4dd-2012-41f2-af80-0950158597fa)
