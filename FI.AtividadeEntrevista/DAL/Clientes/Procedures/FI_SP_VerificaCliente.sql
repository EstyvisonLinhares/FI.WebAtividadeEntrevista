CREATE PROCEDURE FI_SP_VerificaClienteV2 
    @CPF VARCHAR(14)
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM CLIENTES WHERE cpf = @CPF)
    BEGIN
        
        PRINT 'CPF encontrado na tabela CLIENTES.'
    END
    ELSE
    BEGIN
        
        PRINT 'CPF não encontrado na tabela CLIENTES.'
    END
END