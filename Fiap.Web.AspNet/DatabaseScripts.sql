﻿CREATE TABLE REPRESENTANTE ( 
	REPRESENTANTEID NUMBER PRIMARY KEY, 
	NOMEREPRESENTANTE VARCHAR2(80) NOT NULL, 
	CPF VARCHAR2(12) NOT NULL
); 
 
CREATE SEQUENCE REPRESENTANTE_ID_SEQ;  
 
CREATE OR REPLACE TRIGGER TR_SEQ_REPRESENTANTE BEFORE INSERT ON REPRESENTANTE FOR EACH ROW  
BEGIN 
	SELECT REPRESENTANTE_ID_SEQ.NEXTVAL INTO :new.REPRESENTANTEID FROM dual; 
END; 
 
--DROP TRIGGER TR_SEQ_REPRESENTANTE; 
--DROP SEQUENCE REPRESENTANTE_ID_SEQ; 
--DROP TABLE REPRESENTANTE;   


CREATE TABLE CLIENTE ( 
	CLIENTEID NUMBER PRIMARY KEY, 
	NOME VARCHAR2(80) NOT NULL, 
	DATANASCIMENTO DATE,
    OBSERVACAO VARCHAR2(80) NOT NULL, 
    REPRESENTANTEID NUMBER NOT NULL,
    CONSTRAINT FK_REPRESENTANTE
        FOREIGN KEY (REPRESENTANTEID)
        REFERENCES REPRESENTANTE(REPRESENTANTEID)
); 


CREATE SEQUENCE CLIENTE_ID_SEQ;  
 
CREATE OR REPLACE TRIGGER TR_SEQ_CLIENTE BEFORE INSERT ON CLIENTE FOR EACH ROW  
BEGIN 
	SELECT CLIENTE_ID_SEQ.NEXTVAL INTO :new.CLIENTEID FROM dual; 
END; 

--DROP TRIGGER TR_SEQ_CLIENTE; 
--DROP SEQUENCE CLIENTE_ID_SEQ; 
--DROP TABLE CLIENTE;   