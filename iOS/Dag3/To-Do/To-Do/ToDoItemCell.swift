//
//  ToDoItemCell.swift
//  To-Do
//
//  Created by Erik Vestesen on 08/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

class ToDoItemCell: UITableViewCell {

    static let identifier = "todoitemcell"
    
    var name: String? {
        didSet {
            textLabel?.text = name
        }
    }
    
    var completed:Bool = false {
        didSet {
            if(completed) {
             accessoryType = UITableViewCellAccessoryType.Checkmark
            } else {
                accessoryType = UITableViewCellAccessoryType.None
            }
        }
    }

}
