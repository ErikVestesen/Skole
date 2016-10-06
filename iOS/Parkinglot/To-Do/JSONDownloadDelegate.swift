//
//  JSONDownloadDelegate.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 20/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation

protocol JSONDownloadDelegate {
    func finishedDownloadingJSON(JSON: [String: AnyObject])
}