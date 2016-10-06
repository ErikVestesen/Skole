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
    var delegate: ToiletStateControllerDelegate?
    
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
        if let features = data["features"]{
            for feature in features as! NSArray {
                if  let adresse = feature["properties"]!!["Adresse"] as? String,
                    let status = feature["properties"]!!["Status"] as? String,
                    let c1 = feature["geometry"]!!["coordinates"]!![0] as? CLLocationDegrees,
                    let c2 = feature["geometry"]!!["coordinates"]!![1] as? CLLocationDegrees{
                        let toilet = Toilet(Adresse: adresse, Status: status, location: CLLocation(latitude: c1, longitude: c2))
                        items.append(toilet)
                }
            }
            if let delegate = delegate {
                delegate.dataIsReady()
            }
       }
    }
}