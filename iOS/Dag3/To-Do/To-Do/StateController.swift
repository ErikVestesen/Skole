//
//  StateController.swift
//  To-Do
//
//  Created by Erik Vestesen on 08/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import Foundation

class StateController  {
    
    static let itemsFilePath = NSSearchPathForDirectoriesInDomains(.DocumentDirectory, .UserDomainMask, true).first! + Config.storageName.rawValue
    
    private(set) var items = [ToDoItem]()
    
    func addItem(item: ToDoItem) {
        items.append(item)
    }
    func save() {
        
    }
    
    enum Config: String {
        case storageName = "/items.txt"
    }
    
}