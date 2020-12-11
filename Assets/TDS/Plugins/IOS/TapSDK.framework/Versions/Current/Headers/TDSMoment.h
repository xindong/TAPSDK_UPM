//
//  TDSMoment.h
//  TDSMomentSource
//
//  Created by Insomnia on 2020/12/3.
//

#import <Foundation/Foundation.h>


FOUNDATION_EXPORT double TDSMomentVersionNumber;
FOUNDATION_EXPORT const unsigned char TDSMomentVersionString[];

#if __has_include(<TDSMoment/TDSMoment.h>)

#import <TDSMoment/TDSMomentSdk.h>
#import <TDSMoment/TDSMomentAccessToken.h>

#else

#import "TDSMomentSdk.h"
#import "TDSMomentAccessToken.h"

#endif
