//
//  ParkingItem.swift
//  To-Do
//
//  Created by Erik Vestesen on 22/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation

class ParkingItem: NSObject, NSCoding {
    let garageCode: String
    let date: NSDate
    let totalSpaces: Int
    
    init(garageCode: String, date : NSDate, totalSpaces: Int) {
        self.garageCode = garageCode
        self.date = date
        self.totalSpaces = totalSpaces
    }
    
    required init?(coder aDecoder: NSCoder) {
        garageCode = aDecoder.decodeObjectForKey(Keys.GarageCode.rawValue) as! String
        date = aDecoder.decodeObjectForKey(Keys.Date.rawValue) as! NSDate
        totalSpaces = aDecoder.decodeObjectForKey(Keys.TotalSpaces.rawValue) as! Int
    }
    
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeObject(garageCode, forKey: Keys.GarageCode.rawValue)
        aCoder.encodeObject(date, forKey: Keys.Date.rawValue)
        aCoder.encodeObject(totalSpaces, forKey: Keys.TotalSpaces.rawValue)
    }
    
    enum Keys: String {
        case GarageCode = "garagecode"
        case Date = "date"
        case TotalSpaces = "totalspaces"
    }



}