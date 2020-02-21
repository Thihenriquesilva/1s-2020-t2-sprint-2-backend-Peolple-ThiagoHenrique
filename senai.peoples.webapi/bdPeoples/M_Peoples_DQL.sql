USE M_Peoples;
GO

SELECT * FROM TBL_Funcionario;

SELECT IdFuncionario, Nome, Sobrenome FROM TBL_Funcionario;

SELECT * FROM TBL_Funcionario
WHERE Nome = 'Uguinho';

SELECT * FROM TBL_Funcionario
ORDER BY Nome ASC



UPDATE TBL_Funcionario 
SET Nome = 'Zezinho', Sobrenome = 'Galahad'
WHERE IdFuncionario = 3;





UPDATE TBL_Funcionario
SET DataNascimento = '05/07/2000'
WHERE IdFuncionario = 1;

UPDATE TBL_Funcionario
SET DataNascimento = '06/02/1958'
WHERE IdFuncionario = 2;

