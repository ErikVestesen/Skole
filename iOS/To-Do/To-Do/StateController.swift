//
//  StateController.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation


class StateController {
    
    static let itemsFilePath = NSSearchPathForDirectoriesInDomains(.DocumentDirectory, .UserDomainMask, true).first! + Config.storageName.rawValue
    /*
    private(set) var items: [ToDoItem] = {
        if let items = NSKeyedUnarchiver.unarchiveObjectWithFile(StateController.itemsFilePath) as? [ToDoItem] {
            return items
        } else {
            return [ToDoItem]()
        }
    }()
    
     
     func addItem(item: ToDoItem){
     items.append(item)
     }
     */
    
    private(set) var items: [ParkingItem] = {
        if let items = NSKeyedUnarchiver.unarchiveObjectWithFile(StateController.itemsFilePath) as? [ParkingItem] {
            return items
        } else {
            return [ParkingItem]()
        }
    }()
    
    
    func addItem(item: ParkingItem){
        items.append(item)
    }
    
    func removeItemAtIndex(index: Int){
        items.removeAtIndex(index)
    }
    
    enum JSONError: String, ErrorType {
    case NoData = "Error no Data"
    case ConvertionFailed = "Error: Conversion from JSON failed"
    }
    
    func getJSONData(urlParam: String) {
    
        //if(urlParam.characters.count == 0) {return;}
        
        let urlPath = urlParam
        guard let endpoint = NSURL(string: urlPath) else {
            print("Endpoint sked sgu i buks");
            return;
        }
        
        let request = NSMutableURLRequest(URL: endpoint)
        NSURLSession.sharedSession().dataTaskWithRequest(request) {(data,response, error) in
            do {
                guard let data = data else {
                    throw JSONError.NoData
                }
                guard let json = try NSJSONSerialization.JSONObjectWithData(data, options: []) as? NSDictionary else {
                    throw JSONError.ConvertionFailed
                }
                
                if let result = json["result"] {
                    if let parkingArray = result["records"] {
                        for record in (parkingArray as? NSArray)! {
                            if let name = record["garageCode"]!,
                                let totalSpace = record["totalSpaces"]!,
                                //let vehicleCount = record["vehicleCount"]!,
                                let strDate = record["date"]! {
                                self.addItem(ParkingItem(garageCode: name as! String, date: strDate as! NSDate, totalSpaces: totalSpace as! Int))
                                print("PLADSER: \(totalSpace), STED:\(name), DATO:\(strDate)")
                            }
                        }
                    }
                }
                
            } catch let error as JSONError {
                print(error.rawValue)
            } catch let error as NSError {
                print(error.debugDescription)
            }
            
            }.resume()
    }
    
    func save() {
        NSKeyedArchiver.archiveRootObject(self.items, toFile: StateController.itemsFilePath)
    }
    
    enum Config: String {
        case storageName = "/items.txt"
    }
}