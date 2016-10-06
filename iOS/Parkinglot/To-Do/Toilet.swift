//
//  Toilet.swift
//  Parkinglot
//
//  Created by Erik Vestesen on 29/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation
import MapKit

struct Toilet {
    let Status: String
    let Adresse: String
    var Location: CLLocation
    
    init(Adresse: String, Status:String, location:CLLocation) {
        self.Adresse = Adresse
        self.Status = Status
        self.Location = location
    }

}