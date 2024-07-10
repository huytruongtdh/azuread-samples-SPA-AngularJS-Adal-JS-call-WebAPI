# SinglePageApp-AngularJS-DotNet
An AngularJS SPA that uses adal.js to sign users in and make API calls.

A. OPTIONS:

1. OAuth2 Endpoint V1
- "response_type=id_token token"
- return id_token & access_token (access_token for calling API)

2. OAuth2 Endpoint V2
- "response_type=id_token"
- return id_token


B. PROJECT TODOLIST.API
Sample for testing OAuth flow:
- Token-Based (grant_type=password, grant_type=<customgranttyp>)
- Google login (implicit grant)
- Angular login external providers, using default AspNet.Identy.
Scaffoldded by Web API 2 Template with Individuals User Account.
Using existing AcountController to obtain access_token.
The access_token after user logged in via social provider is local access_token, not social provider token

Sample for debugging packages:
- Microsoft.AspNet.Identity.Core
- Microsoft.AspNet.Identity.EntityFramework
- Microsoft.AspNet.Identity.Owin
- Microsoft.Owin.Security.OAuth
- Microsoft.Owin.Security.Google

C. Project TODOSPA48 - SinglePageApp-AngularJS-DotNet
- front-end: AngularJS
- back-end: Web API 2