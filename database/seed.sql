\connect stonedb

CREATE TABLE employees (
  Id serial PRIMARY KEY ,
  EName varchar(20) NOT NULL,
  LastName varchar(50) NOT NULL,
  Doc varchar(11) NOT NULL,
  Sector varchar(50) NOT NULL,
  Salary real NOT NULL,
  DtAdmission date NOT NULL,
  HealthPlan boolean  NOT NULL,
  DentalPlan boolean  NOT NULL,
  Transport boolean  NOT NULL
);

ALTER TABLE employees OWNER TO stone;

INSERT INTO employees (EName, LastName, Doc, Sector, Salary, DtAdmission, HealthPlan, DentalPlan, Transport)
VALUES ('Pablo', 'Alipio', '40552176842', 'Health', 2000, '2017-03-14', true, true, true);