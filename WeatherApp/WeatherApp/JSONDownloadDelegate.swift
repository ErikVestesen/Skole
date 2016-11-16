//
//  JSONDownloadDelegate.swift
//  WeatherApp
//
//  Created by Erik Vestesen on 16/11/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import Foundation

protocol JSONDownloadDelegate {
    func finishedDownloading(data: JSON )
}
