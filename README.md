# Integration

###Goals
1. Simplify integration of multiple different Services/Apis.
2. Fluent Api for Http Client
3. Don't worry about Secrets
   1. Basic Auth 
   2. Api Token in Query Parameter
   3. Oauth 1/2 (TODO)
   4. Bearer Token (TODO)
   5. ...
   4. Easy extensibility for new Services


###Non Goals
1. Building a "pretty Ui"
2. Workflow automation
   1. Should be handled by an external Tool/Library

I really like the simplicity I get from workflow/Integration tools like Zapier or n8n.io.
This library is a proof of concept to try and build something similar in C#.

###Roadmap
1. Add more Authentication formats
2. Add a nice way to handle Responses 
