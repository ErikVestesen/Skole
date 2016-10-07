//
//  ToiletStateController.swift
//  Parkinglot
//
//  Created by Erik Vestesen on 29/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation
import MapKit

class ToiletStateController {
    var delegate: StateControllerDelegate?
    
    private(set) var items = [Toilet]()
    
    func addItem(item: Toilet) {
        items.append(item)
    }
    
    func removeItemAtIndex(index: Int) {
        items.removeAtIndex(index)
    }
}

extension ToiletStateController : JSONDownloadDelegate {
    func finishedDownloadingJSON(data: [String : AnyObject]) {
      /*
      if let result = data["events"] {
        for record in result as! [AnyObject] {
          if let location_latitude = record["location_latitude"] as? String,
            let location_longitude = record["location_longitude"] as? String,
            let location_name = record["location_name"] as? String {
              var toilet = Toilet(Adresse: location_name, Status: "", location: CLLocation(latitude: location_latitude, longitude: location_longitude)
              items.append(toilet)
          }
        }
 
      }*/
        if let features = data["events"]{
            for feature in features as! NSArray {
                if  let c1 = feature["location_latitude"]as? Double,
                    let c2 = feature["location_longitude"] as? Double,
                    let name = feature["location_name"] as? String {
                        let toilet = Toilet(Adresse: name, Status: "", location: CLLocation(latitude: c1, longitude: c2))
                        items.append(toilet)
                }
            }
            if let delegate = delegate {
                delegate.dataIsReady()
            }
       }
    }
}
