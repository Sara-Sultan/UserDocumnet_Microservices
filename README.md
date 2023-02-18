# UserDocumnet_Microservices

Imagine we are using a microservices to create user registration form with images
User information are stored with this structure.

Field NameField TypeValidation RulesFirst nameString• Required
• Max length 20 characters
• Arabic or English letters and spaces
Middle nameString• Max length 40 characters
• Arabic or English letters and spaces
Last nameString• Required
• Max length 20 characters
• Arabic or English letters and spaces
Birth dateDate• Required
• Minimum age is 20 years
Mobile numberString• Required
• Format example +021006158123
Email String• Required
• Valid email
Address ListArray with fields in the next table

Address fields:
Field NameDescriptionValidation RulesGovernateLookup• RequiredCityLookup• RequiredStreetString• Required
• Max length 200 charactersBuilding number• RequiredFlat number• Required
This form will save this information into database through REST API at user Service.
