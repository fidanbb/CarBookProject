
--select Brands.Name as 'BrandName',Pricings.Name,Amount,Model,CoverImageUrl from Cars
--inner join Brands on Brands.BrandID = Cars.BrandID
--inner join CarPricings on CarPricings.CarID = Cars.CarID
--inner join Pricings on CarPricings.PricingID=Pricings.PricingID

SELECT 
    Brands.Name AS BrandName,
    Cars.Model,
    MAX(CASE WHEN Pricings.Name = 'Hourly' THEN CarPricings.Amount END) AS HourlyAmount,
    MAX(CASE WHEN Pricings.Name = 'Daily' THEN CarPricings.Amount END) AS DailyAmount,
    MAX(CASE WHEN Pricings.Name = 'Weekly' THEN CarPricings.Amount END) AS WeeklyAmount,
	MAX(CASE WHEN Pricings.Name = 'Monthly' THEN CarPricings.Amount END) AS MonthlyAmount,

    Cars.CoverImageUrl
FROM 
    Cars
INNER JOIN 
    Brands ON Brands.BrandID = Cars.BrandID
INNER JOIN 
    CarPricings ON CarPricings.CarID = Cars.CarID
INNER JOIN 
    Pricings ON CarPricings.PricingID = Pricings.PricingID
GROUP BY 
    Brands.Name, Cars.Model, Cars.CoverImageUrl;
