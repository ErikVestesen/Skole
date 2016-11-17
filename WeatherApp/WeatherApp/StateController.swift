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
      if let weatherMain = data["weather"][0]["main"].string, let weatherDescription = data["weather"][0]["description"].string, let temp = data["main"]["temp"].double , let humidity = data["main"]["humidity"].double {
        let tempC = temp - 272.15 // Kelvin til Celsius
        let weatherLocation = WeatherLocation(weatherMain: weatherMain, weatherDescription: weatherDescription, temp: tempC.description, humidity: humidity.description)
        self.weatherLocation = weatherLocation
        if self.weatherLocation != nil {
            delegate?.dataIsReady()
        }
        print("\(weatherLocation)")
      }
    }
    
}
