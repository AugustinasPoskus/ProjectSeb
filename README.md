# ProjectSeb
Features that are not fully implemented or need to be improved (was not implemented because of there was lack of time): <br />
•	Increase personal id length (now it is int type)<br />
•	More validations (null checks)<br />
•	Tests<br />
•	More beautiful error messages<br />
•	Database generated from code and every build regenerates.<br />

How to run the application:<br />

Database can be restored by Database.mdf, Database.ldf files (in WebService/App_Data) or these scripts: <br />

CREATE TABLE [dbo].[Customer] (<br />
    [Id]         INT          IDENTITY (1, 1) NOT NULL,<br />
    [PersonalId] INT          NOT NULL,<br />
    [Name]       VARCHAR (50) NOT NULL,<br />
    PRIMARY KEY CLUSTERED ([Id] ASC)<br />
);

CREATE TABLE [dbo].[Agreement] (<br />
    [Id]           INT          IDENTITY (1, 1) NOT NULL,<br />
    [Margin]       DECIMAL (18) NOT NULL,<br />
    [Amount]       DECIMAL (18) NOT NULL,<br />
    [CustomerId]   INT          NOT NULL,<br />
    [BaseRateCode] VARCHAR (50) NOT NULL,<br />
    [Duration]     INT          NOT NULL,<br />
    PRIMARY KEY CLUSTERED ([Id] ASC),<br />
    CONSTRAINT [FK_CUSTOMER] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])<br />
);<br />
can be executed.<br />

Explanation of choices : <br />
The solution consists of two projects: Web application and Service.<br />
Service is the only one who is responsible for data processing, therefore it has repository of customers and agreements. <br />
To make the communication with database easier, I was using Entity Framework. <br />
The project was not vast, so I made just one models file. <br />
To show my service functioning I used it in my web application.<br />

I was planning to do this task in one week, but under these circumstances (time requirements) I had to do this in 3 days (~14 hours).
