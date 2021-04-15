//
//  NSData+TDSGZIP.h
//  TDSCommon
//
//  Created by TapTap-David on 2021/1/22.
//

#import <Foundation/Foundation.h>

@interface NSData (TDSGZIP)

- (nullable NSData *)gzippedDataWithCompressionLevel:(float)level;
- (nullable NSData *)gzippedData;
- (nullable NSData *)gunzippedData;

@end
