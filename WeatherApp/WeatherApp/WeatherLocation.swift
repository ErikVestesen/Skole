//
//  City.swift
//  WeatherApp
//
//  Created by Erik Vestesen on 16/11/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import Foundation

struct WeatherLocation {
    let weatherMain: String
    let weatherDescription: String
    
    init(weatherMain: String, weatherDescription: String) {
        self.weatherMain = weatherMain
        self.weatherDescription = weatherDescription
    }
}
