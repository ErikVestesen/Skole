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
    
    private(set) var items:[ToDoItem] = {
        if let items = NSKeyedUnarchiver.unarchiveObjectWithFile(StateController.itemsFilePath) as? [ToDoItem] {
            return items
        } else {
            return [ToDoItem]()
        }
    }()
    
    func addItem(item: ToDoItem) {
        items.append(item)
    }
    func save() {
        NSKeyedArchiver.archiveRootObject(self.items, toFile: StateController.itemsFilePath)
    }
    
    enum Config: String {
        case storageName = "/items.txt"
    }
    
}