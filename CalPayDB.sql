CREATE TABLE DiscountCoupon
(
promoCode	INT NOT NULL PRIMARY KEY,
name		VARCHAR(30) NOT NULL,
percentage	DECIMAL(5,2) NOT NULL
);

INSERT INTO DiscountCoupon VALUES (1, 'New Year', 0.05);
INSERT INTO DiscountCoupon VALUES (2, 'Lebaran', 0.10);
INSERT INTO DiscountCoupon VALUES (3, 'Harbolnas', 0.20);


