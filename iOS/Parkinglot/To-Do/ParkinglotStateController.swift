//
//  ParkingLotStateController.swift
//  Parkinglot
//
//  Created by Kaj Schermer Didriksen on 20/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation


class ParkinglotStateController {
    
    // delegate to notify when json data is ready
    var delegate: ParkinglotStateControllerDelegate?
    
    private(set) var items = [ParkingLot]()
    
    func addItem(item: ParkingLot){
        items.append(item)
    }
    
    func removeItemAtIndex(index: Int){
        items.removeAtIndex(index)
    }

}

extension ParkinglotStateController: JSONDownloadDelegate{
    

    func finishedDownloadingJSON(data: [String: AnyObject]){
        if let result = data["result"],
            let records = result["records"] {
            for record in records as! NSArray {
                if let date = record["date"] as? String,
                    let name = record["garageCode"] as? String,
                    let totalSpaces = record["totalSpaces"] as? Int,
                    let vehicleCount = record["vehicleCount"] as? Int {
                    
                    let  parkinglot = ParkingLot(name: name, totalSpace: totalSpaces, vehicleCount: vehicleCount, date: date)
                    items.append(parkinglot)
                }
            }
            
            // notify the delegate
            if let delegate = delegate {
                delegate.dataIsReady()
            }
            
        }
    }

}