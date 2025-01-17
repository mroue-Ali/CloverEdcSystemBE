CREATE TABLE Roles
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE Protocols
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    NumOfVisits INT NOT NULL,
    Randomization INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE AdverseEvents
(
    Id uniqueidentifier NOT NULL,
    CrfId uniqueidentifier NOT NULL,
    Description INT NOT NULL,
    Severity INT NOT NULL,
    Treatment INT,
    IsTreated INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE Types
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    VariableType INT NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE Studies
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    Status INT NOT NULL,
    ProtocolId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Protocols(Id)
);

CREATE TABLE CrfTemplate
(
    Id uniqueidentifier NOT NULL,
    StudyId uniqueidentifier NOT NULL,
    Code INT NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Studies(Id)
);

CREATE TABLE CRF
(
    Id uniqueidentifier NOT NULL,
    CrfTemplateId uniqueidentifier NOT NULL,
    PatientId uniqueidentifier NOT NULL,
    CrcId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES CrfTemplate(Id)
);

CREATE TABLE BaseFields
(
    Id uniqueidentifier NOT NULL,
    FieldName INT NOT NULL,
    FieldType INT NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Types(Id)
);

CREATE TABLE DropDownValues
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    BaseFieldId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES BaseFields(Id)
);

CREATE TABLE CrfAdverseEvents
(
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id, Id),
    FOREIGN KEY (Id) REFERENCES CRF(Id),
    FOREIGN KEY (Id) REFERENCES AdverseEvents(Id)
);

CREATE TABLE USERS
(
    Id uniqueidentifier NOT NULL,
    FirstName INT NOT NULL,
    LastName INT NOT NULL,
    UserName INT NOT NULL,
    Email INT NOT NULL,
    Password INT NOT NULL,
    RoleId uniqueidentifier NOT NULL,
    StudyId INT,
    Id uniqueidentifier NOT NULL,
    Id INT,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Roles(Id),
    FOREIGN KEY (Id) REFERENCES Studies(Id)
);

CREATE TABLE PI
(
    Id uniqueidentifier NOT NULL,
    UserId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES USERS(Id)
);

CREATE TABLE CRC
(
    Id uniqueidentifier NOT NULL,
    UserId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES USERS(Id)
);

CREATE TABLE DM
(
    Id uniqueidentifier NOT NULL,
    UserId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES USERS(Id)
);

CREATE TABLE AuditTrail
(
    Id uniqueidentifier NOT NULL,
    UserId uniqueidentifier NOT NULL,
    action INT NOT NULL,
    Timestamp INT NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES USERS(Id)
);

CREATE TABLE Locks
(
    Id uniqueidentifier NOT NULL,
    StudyId uniqueidentifier NOT NULL,
    LockedBy INT NOT NULL,
    Timestamp INT NOT NULL,
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES USERS(Id),
    FOREIGN KEY (Id) REFERENCES Studies(Id)
);

CREATE TABLE CrcCrf
(
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id, Id),
    FOREIGN KEY (Id) REFERENCES CRF(Id),
    FOREIGN KEY (Id) REFERENCES CRC(Id)
);

CREATE TABLE Site
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    Location INT,
    StudyId uniqueidentifier NOT NULL,
    PiId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    Id INT,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Studies(Id),
    FOREIGN KEY (Id) REFERENCES PI(Id)
);

CREATE TABLE Patients
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    Code INT NOT NULL,
    SiteId uniqueidentifier NOT NULL,
    RandomizationArm INT,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES Site(Id)
);

CREATE TABLE TemplateFIle
(
    Id uniqueidentifier NOT NULL,
    Name INT NOT NULL,
    CrfTemplteId uniqueidentifier NOT NULL,
    RequiredFileId INT,
    Id uniqueidentifier NOT NULL,
    FileFile_Id INT,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES CrfTemplate(Id),
    FOREIGN KEY (FileFile_Id) REFERENCES TemplateFIle(Id)
);

CREATE TABLE TemplateField
(
    Id uniqueidentifier NOT NULL,
    TemplateFileId uniqueidentifier NOT NULL,
    FieldName INT NOT NULL,
    ValidationRules INT NOT NULL,
    RequiredFieldId INT,
    IsRequired INT NOT NULL,
    BaseFieldId uniqueidentifier NOT NULL,
    RequiredFieldValueId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES TemplateFIle(Id),
    FOREIGN KEY (Id) REFERENCES BaseFields(Id)
);

CREATE TABLE CrfValues
(
    Id uniqueidentifier NOT NULL,
    TemplateFieldId uniqueidentifier NOT NULL,
    Value INT NOT NULL,
    Status INT NOT NULL,
    IsModified INT NOT NULL,
    ValueId INT,
    CrfFileId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES TemplateField(Id),
    FOREIGN KEY (Id) REFERENCES CrfFile(Id)
);

CREATE TABLE Queries
(
    Id uniqueidentifier NOT NULL,
    DmId uniqueidentifier NOT NULL,
    CrfValueId uniqueidentifier NOT NULL,
    QueryText INT NOT NULL,
    Status INT NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES CrfValues(Id)
);

CREATE TABLE UpdateRequest
(
    Id uniqueidentifier NOT NULL,
    CrfValueId uniqueidentifier NOT NULL,
    NewValue INT NOT NULL,
    Reason INT NOT NULL,
    Status INT NOT NULL,
    SiteId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES CrfValues(Id)
);

CREATE TABLE CrfFile
(
    Id uniqueidentifier NOT NULL,
    TemplateFileId uniqueidentifier NOT NULL,
    DateDone INT NOT NULL,
    CrfId uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (Id) REFERENCES TemplateFIle(Id),
    FOREIGN KEY (Id) REFERENCES CRF(Id)
);

CREATE TABLE DmQuery
(
    Id uniqueidentifier NOT NULL,
    Id uniqueidentifier NOT NULL,
    PRIMARY KEY (Id, Id),
    FOREIGN KEY (Id) REFERENCES Queries(Id),
    FOREIGN KEY (Id) REFERENCES DM(Id)
);