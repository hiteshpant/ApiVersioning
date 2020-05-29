--------------Api Version can be done by 3 ways in .Net core
---------package required : Microsoft.AspNetCore.Mvc.Versioning--------------
1- Url Versioning{worst approach as all client needs to adapt to it}
2- QueryString adding the version{still ok , but fragile by default hits default version}
3- request Header sending the version number (good approach)
 