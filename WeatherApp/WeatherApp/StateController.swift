//
//  StateController.swift
//  WeatherApp
//
//  Created by Erik Vestesen on 16/11/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

class StateController : JSONDownloadDelegate {

    var delegate: StateControllerDelegate?
    
    var weatherLocation: WeatherLocation?
    
    func finishedDownloading(data: JSON) {
        let weatherMain = data["list"][0]["main"].string
        let weatherDescription = data["list"][0]["description"].string
        
        let weatherLocation = WeatherLocation(weatherMain: weatherMain!, weatherDescription: weatherDescription!)
        self.weatherLocation = weatherLocation
        if self.weatherLocation != nil {
            delegate?.dataIsReady()
        }
        print("\(weatherLocation)")
    }
    
}
