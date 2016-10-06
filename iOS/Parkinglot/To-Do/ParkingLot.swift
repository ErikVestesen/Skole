//
//  ParkingLot.swift
//  Parkinglot
//
//  Created by Kaj Schermer Didriksen on 20/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation


struct ParkingLot {
    let name: String
    let totalSpace: Int
    var vehicleCount: Int
    var date: String
    
    init(name: String, totalSpace: Int, vehicleCount: Int, date: String) {
        self.name = name
        self.totalSpace = totalSpace
        self.vehicleCount = vehicleCount
        self.date = date
    }

}