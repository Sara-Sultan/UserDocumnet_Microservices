# UserDocumnet_Microservices
Task Description

Imagine we are using a microservices to create user registration form with images
User information are stored with this structure.
Field Name Field Type Validation Rules
First name String  Required

 Max length 20 characters
 Arabic or English letters and
spaces

Middle name String  Max length 40 characters
 Arabic or English letters and
spaces
Last name String  Required

 Max length 20 characters
 Arabic or English letters and
spaces
Birth date Date  Required

 Minimum age is 20 years

Mobile number String  Required
 Format example
+021006158123
Email String  Required
 Valid email

Address List Array with fields in the

next table

Address fields:
Field Name Description Validation Rules
Governate Lookup  Required
City Lookup  Required
Street String  Required

 Max length 200 characters

Building number  Required
Flat number  Required

This form will save this information into database through REST API at user Service.

Also, we will have a service to store user images using Rest Api at document
service and we need to handle case when delete user info delete images also by
asynchronous message to document service to delete this document
Task requirements &amp; Tools

1- Use angular for UI development
2- Follow clean architecture while developing Rest API as the following
 Domain layer (Use library Entity framework core and
Fluent API)
 Application layer (CQRS, MediatR, FluentValidation)
 Presentation layer (REST .NetCore API - Swagger)
 Persistence layer (DI, Entity framework core, MS SQL
2019)
 Infrastructure layer (Dependency Injection)
 Mapping using AutoMapper
