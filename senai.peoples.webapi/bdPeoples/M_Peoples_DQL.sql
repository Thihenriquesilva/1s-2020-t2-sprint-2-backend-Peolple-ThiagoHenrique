USE M_Peoples;
GO

SELECT * FROM TBL_Funcionario;

SELECT IdFuncionario, Nome, Sobrenome FROM TBL_Funcionario;

UPDATE TBL_Funcionario 
SET Nome = 'Zezinho', Sobrenome = 'Galahad'
WHERE IdFuncionario = 3;
