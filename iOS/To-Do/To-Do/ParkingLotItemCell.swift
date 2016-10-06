//
//  ParkingLotItemCell.swift
//  To-Do
//
//  Created by Erik Vestesen on 22/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class ParkingLotItemCell: UITableViewCell {
    static let identifier = "parkinglotitemcell"
    
    var garageCode: String? {
        didSet {
            textLabel?.text = garageCode
        }
    }
    
    var date: NSDate? {
        didSet {
            textLabel?.text = date?.description // lav ny label til den her
        }
    }
    
    var totalSpaces: Int? {
        didSet {
            textLabel?.text = String(totalSpaces) // lav ny label til den her
        }
    }
}
