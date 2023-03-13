USE [CargoDB]
GO
/****** Object:  StoredProcedure [dbo].[pr_ChatAnalytics]    Script Date: 3/12/2023 7:52:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Shipper_Shipment_Details]

@shipper_id  int 
AS
BEGIN

SELECT 
shipment_id as ShipmentId,
shipper_name as ShipperName,
carrier_name as CarrierName,
shipment_description as ShipmentDescription,
shipment_weight as ShipmentWeight,
shipment_rate_description as ShipmentRateDescription

FROM SHIPMENT shipment
JOIN SHIPPER shipper on shipment.shipper_id = shipper.shipper_id
JOIN CARRIER carrier on shipment.carrier_id = carrier.carrier_id
JOIN SHIPMENT_RATE shipmentRate on shipment.shipment_rate_id = shipmentRate.shipment_rate_id

WHERE shipper.shipper_id = @shipper_id

ORDER BY shipper_name

END