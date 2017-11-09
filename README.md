# ProjectSeb
Features that are not fully implemented or need to be improved (was not implemented because of there was lack of time): 
•	Increase personal id length (now it is int type)
•	More validations (null checks)
•	Tests
•	More beautiful error messages
•	Database generated from code and every build regenerates.

How to run the application:

Database can be restored by Database.mdf, Database.ldf files (in WebService/App_Data) or these scripts: 

CREATE TABLE [dbo].[Customer] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [PersonalId] INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Agreement] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Margin]       DECIMAL (18) NOT NULL,
    [Amount]       DECIMAL (18) NOT NULL,
    [CustomerId]   INT          NOT NULL,
    [BaseRateCode] VARCHAR (50) NOT NULL,
    [Duration]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CUSTOMER] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);
can be executed.

Explanation of choices : 
The solution consists of two projects: Web application and Service.
Service is the only one who is responsible for data processing, therefore it has repository of customers and agreements. 
To make the communication with database easier, I was using Entity Framework. 
The project was not vast, so I made just one models file. 
To show my service functioning I used it in my web application.

I was planning to do this task in one week, but under these circumstances (time requirements) I had to do this in 3 days (~14 hours).
