CREATE TABLE `role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(65) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB;

CREATE TABLE `user_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
   `CreatedDate` datetime NOT NULL,
  `Active` bit NOT NULL DEFAULT b'1',
  PRIMARY KEY (`Id`),
  KEY `user_role_idx` (`UserId`),
  KEY `role_user_idx` (`RoleId`),
  CONSTRAINT `role_user` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`),
  CONSTRAINT `user_role` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB;