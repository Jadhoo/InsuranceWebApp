CREATE DATABASE InsuranceDB


-- ---------------------------------------------Policy type table-----------------------------------------------------------------
CREATE TABLE PolicyType (
	PlanNumber INT PRIMARY KEY IDENTITY(101, 1),
	PolicyName VARCHAR(100) NOT NULL
);

INSERT PolicyType VALUES
	('Jeevan Anand'),
	('Tech Term')

SELECT * FROM PolicyType


--------------------------------------------------------- Participant Types table--------------------------------------------------------------
CREATE TABLE ParticipantTypes (
	ParticipantTypeNo INT PRIMARY KEY IDENTITY(1, 1),
	ParticipantTypeName VARCHAR(25) NOT NULL
)

INSERT ParticipantTypes VALUES
	('Owner'),
	('Insured'),
	('Beneficiary')

SELECT * FROM ParticipantTypes


-------------------------------------------------------- Participants table----------------------------------------------------------------------
CREATE TABLE Participants (
	ParticipantNo INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25),
	MiddleName VARCHAR(25),
	DOB DATE NOT NULL,
	ParticipantTypeNo INT NOT NULL,
	FOREIGN KEY(ParticipantTypeNo) REFERENCES ParticipantTypes(ParticipantTypeNo)
)


INSERT Participants VALUES
	('Bheem', null, null, '1998-05-04', 1),
	('Raju', null, null, '1998-07-02', 2),
	('Chutki', null, null, '1998-06-12', 3),
	('Dolu', null, null, '1999-08-01', 1),
	('Bolu', null, null, '1999-08-01', 2),
	('Dolu', null, null, '1999-08-01', 3)

SELECT * FROM Participants

---------------------------------------------------------- Policies table-------------------------------------------------------------------------

CREATE TABLE Policies (
	PolicyNumber INT PRIMARY KEY IDENTITY(1000, 1),
	PlanNumber INT NOT NULL,
	InstallmentPremium FLOAT NOT NULL,
	Insured INT NOT NULL,
	SumAssured FLOAT NOT NULL,
	PolicyStatus VARCHAR(25) NOT NULL,
	PremiumMode VARCHAR(25) NOT NULL,
	PremiumDueDate DATE NOT NULL,
	Beneficiary INT NOT NULL,
	Owner INT NOT NULL,
	PolicyTerm INT NOT NULL,
	FOREIGN KEY(PlanNumber) REFERENCES PolicyType(PlanNumber),
	FOREIGN KEY(Owner) REFERENCES Participants(ParticipantNo),
	FOREIGN KEY(Insured) REFERENCES Participants(ParticipantNo),
	FOREIGN KEY(Beneficiary) REFERENCES Participants(ParticipantNo)
)


INSERT Policies VALUES
	(101, 5000, 2, 500000, 'Active', 'Monthly', '2021-03-30', 3, 1, 5),
	(102, 10000, 5, 1000000, 'Active', 'Monthly', '2021-03-30', 6, 4, 10)

SELECT * FROM Policies

---------------------------------------------------------------- view for displaying policies----------------------------------------------------
ALTER VIEW vw_Policies
AS
SELECT p.PolicyNumber, PolicyName, InstallmentPremium, par1.FirstName AS Insured, SumAssured, PolicyStatus, PremiumMode, PremiumDueDate, par2.FirstName AS Beneficiary, par3.FirstName AS Owner, PolicyTerm
FROM Policies p JOIN PolicyType pt ON p.PlanNumber = pt.PlanNumber
JOIN Participants par1 ON p.Insured = par1.ParticipantNo
JOIN Participants par2 ON p.Beneficiary = par2.ParticipantNo
JOIN Participants par3 ON p.Owner = par3.ParticipantNo


SELECT * FROM vw_Policies


-----------------------------------------------------SP for populating policy types to drop down list-------------------------------------------
CREATE PROCEDURE usp_GetPolicyTypes
AS
BEGIN
	SELECT PlanNumber, PolicyName FROM PolicyType
END

EXEC usp_GetPolicyTypes


------------------------------------SP for populating participants to drop down list based on their type-------------------------------------------
CREATE PROCEDURE usp_GetParticipantsByType @participantType VARCHAR(20) 
AS
BEGIN
	SELECT ParticipantNo, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS FullName 
	FROM Participants p1 JOIN ParticipantTypes p2
	ON p1.ParticipantTypeNo = p2.ParticipantTypeNo
	WHERE ParticipantTypeName = @participantType
END


DROP PROCEDURE usp_InsertPolicy


--------------------------------------------SP for inserting records to Policies table-----------------------------------------------------
CREATE PROCEDURE usp_InsertPolicy
@planNo INT,
@installmentPremium FLOAT,
@insured INT,
@sumAssured FLOAT,
@policyStatus VARCHAR(25),
@premiumMode VARCHAR(25),
@premiumDueDate date,
@beneficiary INT,
@owner INT,
@policyTerm INT
AS
BEGIN
	INSERT Policies VALUES
	(@planNo, @installmentPremium, @insured, @sumAssured, @policyStatus, @premiumMode, @premiumDueDate, @beneficiary, @owner, @policyTerm)
END

EXEC usp_GetParticipantsByType @participantType = 'Insured'

exec usp_InsertPolicy @planNo = 101, @installmentPremium = 5000.0, @insured = 2, @sumAssured = 500000, @policyStatus = 'Active', @premiumMode = 'Monthly', @premiumDueDate = '2021-03-30', @beneficiary = 3, @owner = 1, @policyTerm = 5



-----------------------------------------------------------SP for updating a record in Policies table--------------------------------------
CREATE PROCEDURE usp_EditPolicy
@policyNumber INT,
@planNo INT,
@installmentPremium FLOAT,
@insured INT,
@sumAssured FLOAT,
@policyStatus VARCHAR(25),
@premiumMode VARCHAR(25),
@premiumDueDate date,
@beneficiary INT,
@owner INT,
@policyTerm INT
AS
BEGIN
	UPDATE Policies
	SET PlanNumber = @planNo,
		InstallmentPremium = @installmentPremium,
		Insured = @insured,
		SumAssured = @sumAssured,
		PolicyStatus = @policyStatus,
		PremiumMode = @premiumMode,
		PremiumDueDate = @premiumDueDate,
		Beneficiary = @beneficiary,
		Owner = @owner,
		PolicyTerm = @policyTerm
	WHERE PolicyNumber = @policyNumber
END


EXEC usp_EditPolicy @policyNumber = 1006, @planNo = 101, @installmentPremium = 10000, @insured = 2, @sumAssured = 1000000, @policyStatus = 'Expired',
@premiumMode='Annual', @premiumDueDate='2021-03-06', @beneficiary = 6, @owner = 4, @policyTerm = 15
SELECT * FROM Policies



--------------------------------------------------SP for deleting a record in Policies table-----------------------------------------------------
CREATE PROCEDURE usp_DeletePolicy
@policyNumber INT
AS
BEGIN
	DELETE FROM Policies WHERE PolicyNumber = @policyNumber
END


-----------------------------------------------------SP for searching for a record in Policies table-------------------------------------------------------
CREATE PROCEDURE usp_SearchPolicy @policyNumber INT
AS
BEGIN
	SELECT PolicyNumber, PlanNumber, InstallmentPremium, Insured, SumAssured, PolicyStatus, PremiumMode, PremiumDueDate, Beneficiary, Owner, PolicyTerm
	FROM Policies WHERE PolicyNumber = @policyNumber
END

EXEC usp_SearchPolicy @policyNumber = 1001
