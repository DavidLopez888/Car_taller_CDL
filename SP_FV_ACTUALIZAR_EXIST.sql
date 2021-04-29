CREATE OR REPLACE PROCEDURE SP_FV_ACTUALIZAR_EXIST(p_rowid_item   IN NUMBER DEFAULT NULL,
                                                   p_cant         IN NUMBER DEFAULT NULL,
                                                   p_rowid_tienda IN NUMBER DEFAULT NULL) AS

BEGIN
  BEGIN
    UPDATE T07_EXISTENCIS
       SET F07_CANT_EXISTENCIA = F07_CANT_EXISTENCIA - p_cant
     WHERE F07_ROWID_ITEM = p_rowid_item
       AND F07_ROWID_TIENDA = p_rowid_tienda;
  END;
END SP_FV_ACTUALIZAR_EXIST;
/
