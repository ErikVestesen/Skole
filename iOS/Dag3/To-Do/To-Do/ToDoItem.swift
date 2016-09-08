//
//  ToDoItem.swift
//  To-Do
//
//  Created by Erik Vestesen on 08/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//  

import Foundation

class ToDoItem: NSObject,NSCoding {
    let name : String
    let creationDate : NSDate
    var completed : Bool
    
    init(name: String, creationDate: NSDate, completed: Bool) {
        self.name = name
        self.creationDate = creationDate
        self.completed = completed
    }
    
    //coder external name, ADecoder internal name.
    /* Decoding a ToDoITem and instantiate it
    It can fail, so the ? at the end of the init */
    required init?(coder ADecoder: NSCoder) {
        name = ADecoder.decodeObjectForKey(Keys.Name.rawValue) as! String
        creationDate = ADecoder.decodeObjectForKey(Keys.CreationDate.rawValue) as! NSDate
        completed = ADecoder.decodeObjectForKey(Keys.Completed.rawValue) as! Bool
    }
    
    /*
    Encodes the instances of the class as a string for easier storing on disc - this func is not responsible for storing on disc.
    My ToDoItem should be able to encode itself, so others can store it
    This one is not required by the protocol, but if you provide it It will be called by someone
    */
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeObject(name,forKey: Keys.Name.rawValue)
        aCoder.encodeObject(creationDate,forKey: Keys.CreationDate.rawValue)
        aCoder.encodeObject(completed,forKey: Keys.Completed.rawValue)
        
    }
    
    enum Keys : String {
        case Name = "name"
        case Completed = "completed"
        case CreationDate = "creationdate"
    }
}