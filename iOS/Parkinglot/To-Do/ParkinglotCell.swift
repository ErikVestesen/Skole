//
//  ParkinglotCell.swift
//
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

class ParkinglotCell: UITableViewCell {

    static let identifier = "parkinglotcell"
    var totalSpace = 0
    var vehicleCount = 0
    
    var name: String? {
        didSet {
            textLabel?.text = name
            if totalSpace - vehicleCount > 0 {
                textLabel?.textColor = UIColor.greenColor()
            } else {
                textLabel?.textColor = UIColor.redColor()
            }
        }
    }
    
    var detail: String? {
        didSet {
            detailTextLabel?.text = detail
        }
    }
    
}
