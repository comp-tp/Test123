﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Accela.Apps.GeoServices.Geocode.Parser
{
    public class UsaAddressParser
    {
        private static Regex addressRegex;

        static string addressPattern = @"
	        ^
    (
		\W*(?<StreetLine>(?:(?:P[\.\ ]?O[\.\ ]?\ )?|(?:\w+\s)?)BOX\ [0-9]+)\W*
           (?:
				(?:
					(?<CITY>[^\d,]+?)?\W*
					(?<STATE>\b(?:ALABAMA|ALASKA|AMERICAN\ SAMOA|ARIZONA|ARKANSAS|CALIFORNIA|COLORADO|CONNECTICUT|DELAWARE|DISTRICT\ OF\ COLUMBIA|FEDERATED\ STATES\ OF\ MICRONESIA|FLORIDA|GEORGIA|GUAM|HAWAII|IDAHO|ILLINOIS|INDIANA|IOWA|KANSAS|KENTUCKY|LOUISIANA|MAINE|MARSHALL\ ISLANDS|MARYLAND|MASSACHUSETTS|MICHIGAN|MINNESOTA|MISSISSIPPI|MISSOURI|MONTANA|NEBRASKA|NEVADA|NEW\ HAMPSHIRE|NEW\ JERSEY|NEW\ MEXICO|NEW\ YORK|NORTH\ CAROLINA|NORTH\ DAKOTA|NORTHERN\ MARIANA\ ISLANDS|OHIO|OKLAHOMA|OREGON|PALAU|PENNSYLVANIA|PUERTO\ RICO|RHODE\ ISLAND|SOUTH\ CAROLINA|SOUTH\ DAKOTA|TENNESSEE|TEXAS|UTAH|VERMONT|VIRGIN\ ISLANDS|VIRGINIA|WASHINGTON|WEST\ VIRGINIA|WISCONSIN|WYOMING|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)\b)?
				)?\W*
           )?
           (?:(?<ZIP>\d{5}(?:-?\d{4})?))?
           \W*
	)
	|
	(
		[^\w\#]*
		(
			((?<HouseNumber>\d+)(?<UnitNumber>(-[0-9])|(\-?[A-Z]))(?=\b))
			|(?<HouseNumber>\d+[\-\ ]?\d+\/\d+)
			|(?<HouseNumber>\d+-?\d*)
			|(?<HouseNumber>[NSWE]\ ?\d+\ ?[NSWE]\ ?\d+)
		)\W*
		(?:
		  (?:(?<StreetName>NORTH|NORTHEAST|EAST|SOUTHEAST|SOUTH|SOUTHWEST|WEST|NORTHWEST|N|NE|E|SE|S|SW|W|NW|N\.|N\.E\.|E\.|S\.E\.|S\.|S\.W\.|W\.|N\.W\.)\W+
			 (?<StreetType>ALLEE|ALLEY|ALLY|ANEX|ANNEX|ANNX|ARCADE|AV|AVEN|AVENU|AVENUE|AVN|AVNUE|BAYOO|BAYOU|BEACH|BEND|BLUF|BLUFF|BLUFFS|BOT|BOTTM|BOTTOM|BOUL|BOULEVARD|BOULV|BRANCH|BRDGE|BRIDGE|BRNCH|BROOK|BROOKS|BURG|BURGS|BYPA|BYPAS|BYPASS|BYPS|CAMP|CANYN|CANYON|CAPE|CAUSEWAY|CAUSWAY|CEN|CENT|CENTER|CENTERS|CENTR|CENTRE|CIRC|CIRCL|CIRCLE|CIRCLES|CK|CLIFF|CLIFFS|CLUB|CMP|CNTER|CNTR|CNYN|COMMON|CORNER|CORNERS|COURSE|COURT|COURTS|COVE|COVES|CR|CRCL|CRCLE|CRECENT|CREEK|CRESCENT|CRESENT|CREST|CROSSING|CROSSROAD|CRSCNT|CRSENT|CRSNT|CRSSING|CRSSNG|CRT|CURVE|DALE|DAM|DIV|DIVIDE|DRIV|DRIVE|DRIVES|DRV|DVD|ESTATE|ESTATES|EXP|EXPR|EXPRESS|EXPRESSWAY|EXPW|EXTENSION|EXTENSIONS|EXTN|EXTNSN|FALLS|FERRY|FIELD|FIELDS|FLAT|FLATS|FORD|FORDS|FOREST|FORESTS|FORG|FORGE|FORGES|FORK|FORKS|FORT|FREEWAY|FREEWY|FRRY|FRT|FRWAY|FRWY|GARDEN|GARDENS|GARDN|GATEWAY|GATEWY|GATWAY|GLEN|GLENS|GRDEN|GRDN|GRDNS|GREEN|GREENS|GROV|GROVE|GROVES|GTWAY|HARB|HARBOR|HARBORS|HARBR|HAVEN|HAVN|HEIGHT|HEIGHTS|HGTS|HIGHWAY|HIGHWY|HILL|HILLS|HIWAY|HIWY|HLLW|HOLLOW|HOLLOWS|HOLWS|HRBOR|HT|HWAY|INLET|ISLAND|ISLANDS|ISLES|ISLND|ISLNDS|JCTION|JCTN|JCTNS|JUNCTION|JUNCTIONS|JUNCTN|JUNCTON|KEY|KEYS|KNOL|KNOLL|KNOLLS|LA|LAKE|LAKES|LANDING|LANE|LANES|LDGE|LIGHT|LIGHTS|LNDNG|LOAF|LOCK|LOCKS|LODG|LODGE|LOOPS|MANOR|MANORS|MEADOW|MEADOWS|MEDOWS|MILL|MILLS|MISSION|MISSN|MNT|MNTAIN|MNTN|MNTNS|MOTORWAY|MOUNT|MOUNTAIN|MOUNTAINS|MOUNTIN|MSSN|MTIN|NECK|ORCHARD|ORCHRD|OVERPASS|OVL|PARKS|PARKWAY|PARKWAYS|PARKWY|PASSAGE|PATHS|PIKES|PINE|PINES|PK|PKWAY|PKWYS|PKY|PLACE|PLAIN|PLAINES|PLAINS|PLAZA|PLZA|POINT|POINTS|PORT|PORTS|PRAIRIE|PRARIE|PRK|PRR|RAD|RADIAL|RADIEL|RANCH|RANCHES|RAPID|RAPIDS|RDGE|REST|RIDGE|RIDGES|RIVER|RIVR|RNCHS|ROAD|ROADS|ROUTE|RVR|SHOAL|SHOALS|SHOAR|SHOARS|SHORE|SHORES|SKYWAY|SPNG|SPNGS|SPRING|SPRINGS|SPRNG|SPRNGS|SPURS|SQR|SQRE|SQRS|SQU|SQUARE|SQUARES|STATION|STATN|STN|STR|STRAV|STRAVE|STRAVEN|STRAVENUE|STRAVN|STREAM|STREET|STREETS|STREME|STRT|STRVN|STRVNUE|SUMIT|SUMITT|SUMMIT|TERR|TERRACE|THROUGHWAY|TPK|TR|TRACE|TRACES|TRACK|TRACKS|TRAFFICWAY|TRAIL|TRAILS|TRK|TRKS|TRLS|TRNPK|TRPK|TUNEL|TUNLS|TUNNEL|TUNNELS|TUNNL|TURNPIKE|TURNPK|UNDERPASS|UNION|UNIONS|VALLEY|VALLEYS|VALLY|VDCT|VIADCT|VIADUCT|VIEW|VIEWS|VILL|VILLAG|VILLAGE|VILLAGES|VILLE|VILLG|VILLIAGE|VIST|VISTA|VLLY|VST|VSTA|WALKS|WELL|WELLS|WY|ALY|ANX|ARC|AVE|BYU|BCH|BND|BLF|BLFS|BTM|BLVD|BR|BRG|BRK|BRKS|BG|BGS|BYP|CP|CYN|CPE|CSWY|CTR|CTRS|CIR|CIRS|CRK|CLF|CLFS|CLB|CMN|COR|CORS|CRSE|CT|CTS|CV|CVS|CRES|CRST|XING|XRD|CURV|DL|DM|DV|DR|DRS|EST|ESTS|EXPY|EXT|EXTS|FLS|FRY|FLD|FLDS|FLT|FLTS|FRD|FRDS|FRST|FRG|FRGS|FRK|FRKS|FT|FWY|GDN|GDNS|GTWY|GLN|GLNS|GRN|GRNS|GRV|GRVS|HBR|HBRS|HVN|HTS|HWY|HL|HLS|HOLW|INLT|IS|ISS|ISLE|JCT|JCTS|KY|KYS|KNL|KNLS|LN|LK|LKS|LNDG|LDG|LGT|LGTS|LF|LCK|LCKS|LOOP|MNR|MNRS|MDW|MDWS|ML|MLS|MSN|MT|MTN|MTNS|MTWY|NCK|ORCH|OPAS|OVAL|PARK|PKWY|PSGE|PATH|PIKE|PNE|PNES|PL|PLN|PLNS|PLZ|PT|PTS|PRT|PRTS|PR|RADL|RNCH|RPD|RPDS|RDG|RST|RDGS|RIV|RD|RDS|RTE|SHL|SHLS|SHR|SHRS|SKWY|SPG|SPGS|SPUR|SQ|SQS|STA|ST|STRA|STRM|STS|SMT|TER|TRWY|TPKE|TRL|TRCE|TRAK|TRFY|TUNL|UPAS|UN|UNS|VLY|VLYS|VIA|VW|VWS|VLG|VLGS|VL|VIS|WALK|WL|WLS|WAY)\b
             (?!\W+(?:ALLEE|ALLEY|ALLY|ANEX|ANNEX|ANNX|ARCADE|AV|AVEN|AVENU|AVENUE|AVN|AVNUE|BAYOO|BAYOU|BEACH|BEND|BLUF|BLUFF|BLUFFS|BOT|BOTTM|BOTTOM|BOUL|BOULEVARD|BOULV|BRANCH|BRDGE|BRIDGE|BRNCH|BROOK|BROOKS|BURG|BURGS|BYPA|BYPAS|BYPASS|BYPS|CAMP|CANYN|CANYON|CAPE|CAUSEWAY|CAUSWAY|CEN|CENT|CENTER|CENTERS|CENTR|CENTRE|CIRC|CIRCL|CIRCLE|CIRCLES|CK|CLIFF|CLIFFS|CLUB|CMP|CNTER|CNTR|CNYN|COMMON|CORNER|CORNERS|COURSE|COURT|COURTS|COVE|COVES|CR|CRCL|CRCLE|CRECENT|CREEK|CRESCENT|CRESENT|CREST|CROSSING|CROSSROAD|CRSCNT|CRSENT|CRSNT|CRSSING|CRSSNG|CRT|CURVE|DALE|DAM|DIV|DIVIDE|DRIV|DRIVE|DRIVES|DRV|DVD|ESTATE|ESTATES|EXP|EXPR|EXPRESS|EXPRESSWAY|EXPW|EXTENSION|EXTENSIONS|EXTN|EXTNSN|FALLS|FERRY|FIELD|FIELDS|FLAT|FLATS|FORD|FORDS|FOREST|FORESTS|FORG|FORGE|FORGES|FORK|FORKS|FORT|FREEWAY|FREEWY|FRRY|FRT|FRWAY|FRWY|GARDEN|GARDENS|GARDN|GATEWAY|GATEWY|GATWAY|GLEN|GLENS|GRDEN|GRDN|GRDNS|GREEN|GREENS|GROV|GROVE|GROVES|GTWAY|HARB|HARBOR|HARBORS|HARBR|HAVEN|HAVN|HEIGHT|HEIGHTS|HGTS|HIGHWAY|HIGHWY|HILL|HILLS|HIWAY|HIWY|HLLW|HOLLOW|HOLLOWS|HOLWS|HRBOR|HT|HWAY|INLET|ISLAND|ISLANDS|ISLES|ISLND|ISLNDS|JCTION|JCTN|JCTNS|JUNCTION|JUNCTIONS|JUNCTN|JUNCTON|KEY|KEYS|KNOL|KNOLL|KNOLLS|LA|LAKE|LAKES|LANDING|LANE|LANES|LDGE|LIGHT|LIGHTS|LNDNG|LOAF|LOCK|LOCKS|LODG|LODGE|LOOPS|MANOR|MANORS|MEADOW|MEADOWS|MEDOWS|MILL|MILLS|MISSION|MISSN|MNT|MNTAIN|MNTN|MNTNS|MOTORWAY|MOUNT|MOUNTAIN|MOUNTAINS|MOUNTIN|MSSN|MTIN|NECK|ORCHARD|ORCHRD|OVERPASS|OVL|PARKS|PARKWAY|PARKWAYS|PARKWY|PASSAGE|PATHS|PIKES|PINE|PINES|PK|PKWAY|PKWYS|PKY|PLACE|PLAIN|PLAINES|PLAINS|PLAZA|PLZA|POINT|POINTS|PORT|PORTS|PRAIRIE|PRARIE|PRK|PRR|RAD|RADIAL|RADIEL|RANCH|RANCHES|RAPID|RAPIDS|RDGE|REST|RIDGE|RIDGES|RIVER|RIVR|RNCHS|ROAD|ROADS|ROUTE|RVR|SHOAL|SHOALS|SHOAR|SHOARS|SHORE|SHORES|SKYWAY|SPNG|SPNGS|SPRING|SPRINGS|SPRNG|SPRNGS|SPURS|SQR|SQRE|SQRS|SQU|SQUARE|SQUARES|STATION|STATN|STN|STR|STRAV|STRAVE|STRAVEN|STRAVENUE|STRAVN|STREAM|STREET|STREETS|STREME|STRT|STRVN|STRVNUE|SUMIT|SUMITT|SUMMIT|TERR|TERRACE|THROUGHWAY|TPK|TR|TRACE|TRACES|TRACK|TRACKS|TRAFFICWAY|TRAIL|TRAILS|TRK|TRKS|TRLS|TRNPK|TRPK|TUNEL|TUNLS|TUNNEL|TUNNELS|TUNNL|TURNPIKE|TURNPK|UNDERPASS|UNION|UNIONS|VALLEY|VALLEYS|VALLY|VDCT|VIADCT|VIADUCT|VIEW|VIEWS|VILL|VILLAG|VILLAGE|VILLAGES|VILLE|VILLG|VILLIAGE|VIST|VISTA|VLLY|VST|VSTA|WALKS|WELL|WELLS|WY|ALY|ANX|ARC|AVE|BYU|BCH|BND|BLF|BLFS|BTM|BLVD|BR|BRG|BRK|BRKS|BG|BGS|BYP|CP|CYN|CPE|CSWY|CTR|CTRS|CIR|CIRS|CRK|CLF|CLFS|CLB|CMN|COR|CORS|CRSE|CT|CTS|CV|CVS|CRES|CRST|XING|XRD|CURV|DL|DM|DV|DR|DRS|EST|ESTS|EXPY|EXT|EXTS|FLS|FRY|FLD|FLDS|FLT|FLTS|FRD|FRDS|FRST|FRG|FRGS|FRK|FRKS|FT|FWY|GDN|GDNS|GTWY|GLN|GLNS|GRN|GRNS|GRV|GRVS|HBR|HBRS|HVN|HTS|HWY|HL|HLS|HOLW|INLT|IS|ISS|ISLE|JCT|JCTS|KY|KYS|KNL|KNLS|LN|LK|LKS|LNDG|LDG|LGT|LGTS|LF|LCK|LCKS|LOOP|MNR|MNRS|MDW|MDWS|ML|MLS|MSN|MT|MTN|MTNS|MTWY|NCK|ORCH|OPAS|OVAL|PARK|PKWY|PSGE|PATH|PIKE|PNE|PNES|PL|PLN|PLNS|PLZ|PT|PTS|PRT|PRTS|PR|RADL|RNCH|RPD|RPDS|RDG|RST|RDGS|RIV|RD|RDS|RTE|SHL|SHLS|SHR|SHRS|SKWY|SPG|SPGS|SPUR|SQ|SQS|STA|ST|STRA|STRM|STS|SMT|TER|TRWY|TPKE|TRL|TRCE|TRAK|TRFY|TUNL|UPAS|UN|UNS|VLY|VLYS|VIA|VW|VWS|VLG|VLGS|VL|VIS|WALK|WL|WLS|WAY))
		  )
		  |
		  (?:(?<StreetPrefixDirection>NORTH|NORTHEAST|EAST|SOUTHEAST|SOUTH|SOUTHWEST|WEST|NORTHWEST|N|NE|E|SE|S|SW|W|NW|N\.|N\.E\.|E\.|S\.E\.|S\.|S\.W\.|W\.|N\.W\.)\W+)?
		  (?:
			(?<StreetName>[^,]*\d)
			(?:[^\w,]*(?<StreetDirection>NORTH|NORTHEAST|EAST|SOUTHEAST|SOUTH|SOUTHWEST|WEST|NORTHWEST|N|NE|E|SE|S|SW|W|NW|N\.|N\.E\.|E\.|S\.E\.|S\.|S\.W\.|W\.|N\.W\.)\b)
		   |
			(?<StreetName>[^,]+)
			(?:[^\w,]+(?<StreetType>ALLEE|ALLEY|ALLY|ANEX|ANNEX|ANNX|ARCADE|AV|AVEN|AVENU|AVENUE|AVN|AVNUE|BAYOO|BAYOU|BEACH|BEND|BLUF|BLUFF|BLUFFS|BOT|BOTTM|BOTTOM|BOUL|BOULEVARD|BOULV|BRANCH|BRDGE|BRIDGE|BRNCH|BROOK|BROOKS|BURG|BURGS|BYPA|BYPAS|BYPASS|BYPS|CAMP|CANYN|CANYON|CAPE|CAUSEWAY|CAUSWAY|CEN|CENT|CENTER|CENTERS|CENTR|CENTRE|CIRC|CIRCL|CIRCLE|CIRCLES|CK|CLIFF|CLIFFS|CLUB|CMP|CNTER|CNTR|CNYN|COMMON|CORNER|CORNERS|COURSE|COURT|COURTS|COVE|COVES|CR|CRCL|CRCLE|CRECENT|CREEK|CRESCENT|CRESENT|CREST|CROSSING|CROSSROAD|CRSCNT|CRSENT|CRSNT|CRSSING|CRSSNG|CRT|CURVE|DALE|DAM|DIV|DIVIDE|DRIV|DRIVE|DRIVES|DRV|DVD|ESTATE|ESTATES|EXP|EXPR|EXPRESS|EXPRESSWAY|EXPW|EXTENSION|EXTENSIONS|EXTN|EXTNSN|FALLS|FERRY|FIELD|FIELDS|FLAT|FLATS|FORD|FORDS|FOREST|FORESTS|FORG|FORGE|FORGES|FORK|FORKS|FORT|FREEWAY|FREEWY|FRRY|FRT|FRWAY|FRWY|GARDEN|GARDENS|GARDN|GATEWAY|GATEWY|GATWAY|GLEN|GLENS|GRDEN|GRDN|GRDNS|GREEN|GREENS|GROV|GROVE|GROVES|GTWAY|HARB|HARBOR|HARBORS|HARBR|HAVEN|HAVN|HEIGHT|HEIGHTS|HGTS|HIGHWAY|HIGHWY|HILL|HILLS|HIWAY|HIWY|HLLW|HOLLOW|HOLLOWS|HOLWS|HRBOR|HT|HWAY|INLET|ISLAND|ISLANDS|ISLES|ISLND|ISLNDS|JCTION|JCTN|JCTNS|JUNCTION|JUNCTIONS|JUNCTN|JUNCTON|KEY|KEYS|KNOL|KNOLL|KNOLLS|LA|LAKE|LAKES|LANDING|LANE|LANES|LDGE|LIGHT|LIGHTS|LNDNG|LOAF|LOCK|LOCKS|LODG|LODGE|LOOPS|MANOR|MANORS|MEADOW|MEADOWS|MEDOWS|MILL|MILLS|MISSION|MISSN|MNT|MNTAIN|MNTN|MNTNS|MOTORWAY|MOUNT|MOUNTAIN|MOUNTAINS|MOUNTIN|MSSN|MTIN|NECK|ORCHARD|ORCHRD|OVERPASS|OVL|PARKS|PARKWAY|PARKWAYS|PARKWY|PASSAGE|PATHS|PIKES|PINE|PINES|PK|PKWAY|PKWYS|PKY|PLACE|PLAIN|PLAINES|PLAINS|PLAZA|PLZA|POINT|POINTS|PORT|PORTS|PRAIRIE|PRARIE|PRK|PRR|RAD|RADIAL|RADIEL|RANCH|RANCHES|RAPID|RAPIDS|RDGE|REST|RIDGE|RIDGES|RIVER|RIVR|RNCHS|ROAD|ROADS|ROUTE|RVR|SHOAL|SHOALS|SHOAR|SHOARS|SHORE|SHORES|SKYWAY|SPNG|SPNGS|SPRING|SPRINGS|SPRNG|SPRNGS|SPURS|SQR|SQRE|SQRS|SQU|SQUARE|SQUARES|STATION|STATN|STN|STR|STRAV|STRAVE|STRAVEN|STRAVENUE|STRAVN|STREAM|STREET|STREETS|STREME|STRT|STRVN|STRVNUE|SUMIT|SUMITT|SUMMIT|TERR|TERRACE|THROUGHWAY|TPK|TR|TRACE|TRACES|TRACK|TRACKS|TRAFFICWAY|TRAIL|TRAILS|TRK|TRKS|TRLS|TRNPK|TRPK|TUNEL|TUNLS|TUNNEL|TUNNELS|TUNNL|TURNPIKE|TURNPK|UNDERPASS|UNION|UNIONS|VALLEY|VALLEYS|VALLY|VDCT|VIADCT|VIADUCT|VIEW|VIEWS|VILL|VILLAG|VILLAGE|VILLAGES|VILLE|VILLG|VILLIAGE|VIST|VISTA|VLLY|VST|VSTA|WALKS|WELL|WELLS|WY|ALY|ANX|ARC|AVE|BYU|BCH|BND|BLF|BLFS|BTM|BLVD|BR|BRG|BRK|BRKS|BG|BGS|BYP|CP|CYN|CPE|CSWY|CTR|CTRS|CIR|CIRS|CRK|CLF|CLFS|CLB|CMN|COR|CORS|CRSE|CT|CTS|CV|CVS|CRES|CRST|XING|XRD|CURV|DL|DM|DV|DR|DRS|EST|ESTS|EXPY|EXT|EXTS|FLS|FRY|FLD|FLDS|FLT|FLTS|FRD|FRDS|FRST|FRG|FRGS|FRK|FRKS|FT|FWY|GDN|GDNS|GTWY|GLN|GLNS|GRN|GRNS|GRV|GRVS|HBR|HBRS|HVN|HTS|HWY|HL|HLS|HOLW|INLT|IS|ISS|ISLE|JCT|JCTS|KY|KYS|KNL|KNLS|LN|LK|LKS|LNDG|LDG|LGT|LGTS|LF|LCK|LCKS|LOOP|MNR|MNRS|MDW|MDWS|ML|MLS|MSN|MT|MTN|MTNS|MTWY|NCK|ORCH|OPAS|OVAL|PARK|PKWY|PSGE|PATH|PIKE|PNE|PNES|PL|PLN|PLNS|PLZ|PT|PTS|PRT|PRTS|PR|RADL|RNCH|RPD|RPDS|RDG|RST|RDGS|RIV|RD|RDS|RTE|SHL|SHLS|SHR|SHRS|SKWY|SPG|SPGS|SPUR|SQ|SQS|STA|ST|STRA|STRM|STS|SMT|TER|TRWY|TPKE|TRL|TRCE|TRAK|TRFY|TUNL|UPAS|UN|UNS|VLY|VLYS|VIA|VW|VWS|VLG|VLGS|VL|VIS|WALK|WL|WLS|WAY)\b)
			(?:[^\w,]+(?<StreetDirection>NORTH|NORTHEAST|EAST|SOUTHEAST|SOUTH|SOUTHWEST|WEST|NORTHWEST|N|NE|E|SE|S|SW|W|NW|N\.|N\.E\.|E\.|S\.E\.|S\.|S\.W\.|W\.|N\.W\.)\b)?
		   |
			(?<StreetName>[^,]+?)
			(?:[^\w,]+(?<StreetType>ALLEE|ALLEY|ALLY|ANEX|ANNEX|ANNX|ARCADE|AV|AVEN|AVENU|AVENUE|AVN|AVNUE|BAYOO|BAYOU|BEACH|BEND|BLUF|BLUFF|BLUFFS|BOT|BOTTM|BOTTOM|BOUL|BOULEVARD|BOULV|BRANCH|BRDGE|BRIDGE|BRNCH|BROOK|BROOKS|BURG|BURGS|BYPA|BYPAS|BYPASS|BYPS|CAMP|CANYN|CANYON|CAPE|CAUSEWAY|CAUSWAY|CEN|CENT|CENTER|CENTERS|CENTR|CENTRE|CIRC|CIRCL|CIRCLE|CIRCLES|CK|CLIFF|CLIFFS|CLUB|CMP|CNTER|CNTR|CNYN|COMMON|CORNER|CORNERS|COURSE|COURT|COURTS|COVE|COVES|CR|CRCL|CRCLE|CRECENT|CREEK|CRESCENT|CRESENT|CREST|CROSSING|CROSSROAD|CRSCNT|CRSENT|CRSNT|CRSSING|CRSSNG|CRT|CURVE|DALE|DAM|DIV|DIVIDE|DRIV|DRIVE|DRIVES|DRV|DVD|ESTATE|ESTATES|EXP|EXPR|EXPRESS|EXPRESSWAY|EXPW|EXTENSION|EXTENSIONS|EXTN|EXTNSN|FALLS|FERRY|FIELD|FIELDS|FLAT|FLATS|FORD|FORDS|FOREST|FORESTS|FORG|FORGE|FORGES|FORK|FORKS|FORT|FREEWAY|FREEWY|FRRY|FRT|FRWAY|FRWY|GARDEN|GARDENS|GARDN|GATEWAY|GATEWY|GATWAY|GLEN|GLENS|GRDEN|GRDN|GRDNS|GREEN|GREENS|GROV|GROVE|GROVES|GTWAY|HARB|HARBOR|HARBORS|HARBR|HAVEN|HAVN|HEIGHT|HEIGHTS|HGTS|HIGHWAY|HIGHWY|HILL|HILLS|HIWAY|HIWY|HLLW|HOLLOW|HOLLOWS|HOLWS|HRBOR|HT|HWAY|INLET|ISLAND|ISLANDS|ISLES|ISLND|ISLNDS|JCTION|JCTN|JCTNS|JUNCTION|JUNCTIONS|JUNCTN|JUNCTON|KEY|KEYS|KNOL|KNOLL|KNOLLS|LA|LAKE|LAKES|LANDING|LANE|LANES|LDGE|LIGHT|LIGHTS|LNDNG|LOAF|LOCK|LOCKS|LODG|LODGE|LOOPS|MANOR|MANORS|MEADOW|MEADOWS|MEDOWS|MILL|MILLS|MISSION|MISSN|MNT|MNTAIN|MNTN|MNTNS|MOTORWAY|MOUNT|MOUNTAIN|MOUNTAINS|MOUNTIN|MSSN|MTIN|NECK|ORCHARD|ORCHRD|OVERPASS|OVL|PARKS|PARKWAY|PARKWAYS|PARKWY|PASSAGE|PATHS|PIKES|PINE|PINES|PK|PKWAY|PKWYS|PKY|PLACE|PLAIN|PLAINES|PLAINS|PLAZA|PLZA|POINT|POINTS|PORT|PORTS|PRAIRIE|PRARIE|PRK|PRR|RAD|RADIAL|RADIEL|RANCH|RANCHES|RAPID|RAPIDS|RDGE|REST|RIDGE|RIDGES|RIVER|RIVR|RNCHS|ROAD|ROADS|ROUTE|RVR|SHOAL|SHOALS|SHOAR|SHOARS|SHORE|SHORES|SKYWAY|SPNG|SPNGS|SPRING|SPRINGS|SPRNG|SPRNGS|SPURS|SQR|SQRE|SQRS|SQU|SQUARE|SQUARES|STATION|STATN|STN|STR|STRAV|STRAVE|STRAVEN|STRAVENUE|STRAVN|STREAM|STREET|STREETS|STREME|STRT|STRVN|STRVNUE|SUMIT|SUMITT|SUMMIT|TERR|TERRACE|THROUGHWAY|TPK|TR|TRACE|TRACES|TRACK|TRACKS|TRAFFICWAY|TRAIL|TRAILS|TRK|TRKS|TRLS|TRNPK|TRPK|TUNEL|TUNLS|TUNNEL|TUNNELS|TUNNL|TURNPIKE|TURNPK|UNDERPASS|UNION|UNIONS|VALLEY|VALLEYS|VALLY|VDCT|VIADCT|VIADUCT|VIEW|VIEWS|VILL|VILLAG|VILLAGE|VILLAGES|VILLE|VILLG|VILLIAGE|VIST|VISTA|VLLY|VST|VSTA|WALKS|WELL|WELLS|WY|ALY|ANX|ARC|AVE|BYU|BCH|BND|BLF|BLFS|BTM|BLVD|BR|BRG|BRK|BRKS|BG|BGS|BYP|CP|CYN|CPE|CSWY|CTR|CTRS|CIR|CIRS|CRK|CLF|CLFS|CLB|CMN|COR|CORS|CRSE|CT|CTS|CV|CVS|CRES|CRST|XING|XRD|CURV|DL|DM|DV|DR|DRS|EST|ESTS|EXPY|EXT|EXTS|FLS|FRY|FLD|FLDS|FLT|FLTS|FRD|FRDS|FRST|FRG|FRGS|FRK|FRKS|FT|FWY|GDN|GDNS|GTWY|GLN|GLNS|GRN|GRNS|GRV|GRVS|HBR|HBRS|HVN|HTS|HWY|HL|HLS|HOLW|INLT|IS|ISS|ISLE|JCT|JCTS|KY|KYS|KNL|KNLS|LN|LK|LKS|LNDG|LDG|LGT|LGTS|LF|LCK|LCKS|LOOP|MNR|MNRS|MDW|MDWS|ML|MLS|MSN|MT|MTN|MTNS|MTWY|NCK|ORCH|OPAS|OVAL|PARK|PKWY|PSGE|PATH|PIKE|PNE|PNES|PL|PLN|PLNS|PLZ|PT|PTS|PRT|PRTS|PR|RADL|RNCH|RPD|RPDS|RDG|RST|RDGS|RIV|RD|RDS|RTE|SHL|SHLS|SHR|SHRS|SKWY|SPG|SPGS|SPUR|SQ|SQS|STA|ST|STRA|STRM|STS|SMT|TER|TRWY|TPKE|TRL|TRCE|TRAK|TRFY|TUNL|UPAS|UN|UNS|VLY|VLYS|VIA|VW|VWS|VLG|VLGS|VL|VIS|WALK|WL|WLS|WAY)\b)?
			(?:[^\w,]+(?<StreetDirection>NORTH|NORTHEAST|EAST|SOUTHEAST|SOUTH|SOUTHWEST|WEST|NORTHWEST|N|NE|E|SE|S|SW|W|NW|N\.|N\.E\.|E\.|S\.E\.|S\.|S\.W\.|W\.|N\.W\.)\b)?
		  )
		)
		(?:
			\W+(
				(:?
					(?: (?:(?<UnitType>SU?I?TE|(?:AP)(?:AR)?T(?:ME?NT)?|(?:DEP)(?:AR)?T(?:ME?NT)?|RO*M|FLO*R?|UNI?T|BU?I?LDI?N?G|HA?NGA?R|KEY|LO?T|PIER|SLIP|SPA?CE?|STOP|TRA?I?LE?R|BOX)(?![a-z]))
						| (?<UnitType>\#)
					)\W*
					(?<UnitNumber>[\w-]+)
				)
				|(?<UnitType>BA?SE?ME?N?T|FRO?NT|LO?BBY|LOWE?R|OFF?I?CE?|PE?N?T?HO?U?S?E?|REAR|SIDE|UPPE?R)\b
			),?
		)?
        (?:\W+
				(?:
					(?<CITY>\b[^\d,]+?\b)?\W*
					(?<STATE>\b(?:ALABAMA|ALASKA|AMERICAN\ SAMOA|ARIZONA|ARKANSAS|CALIFORNIA|COLORADO|CONNECTICUT|DELAWARE|DISTRICT\ OF\ COLUMBIA|FEDERATED\ STATES\ OF\ MICRONESIA|FLORIDA|GEORGIA|GUAM|HAWAII|IDAHO|ILLINOIS|INDIANA|IOWA|KANSAS|KENTUCKY|LOUISIANA|MAINE|MARSHALL\ ISLANDS|MARYLAND|MASSACHUSETTS|MICHIGAN|MINNESOTA|MISSISSIPPI|MISSOURI|MONTANA|NEBRASKA|NEVADA|NEW\ HAMPSHIRE|NEW\ JERSEY|NEW\ MEXICO|NEW\ YORK|NORTH\ CAROLINA|NORTH\ DAKOTA|NORTHERN\ MARIANA\ ISLANDS|OHIO|OKLAHOMA|OREGON|PALAU|PENNSYLVANIA|PUERTO\ RICO|RHODE\ ISLAND|SOUTH\ CAROLINA|SOUTH\ DAKOTA|TENNESSEE|TEXAS|UTAH|VERMONT|VIRGIN\ ISLANDS|VIRGINIA|WASHINGTON|WEST\ VIRGINIA|WISCONSIN|WYOMING|AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)\b)?
				)?\W*
           )?
           (?:(?<ZIP>\d{5}(?:-?\d{4})?))?
		\W*
        (?:UNITED\W*STATES|USA|US)?
	)
	$
";

        private static string[] fields =
            new[]
            {
                "HouseNumber",
                "StreetPrefixDirection",
                "StreetName",
                "StreetLine",
                "StreetType",
                "StreetDirection",
                "CITY",
                "STATE",
                "ZIP",
                "UnitType",
                "UnitNumber"
            };

        static UsaAddressParser()
        {
            addressRegex = new Regex(
                addressPattern,
                RegexOptions.IgnoreCase |
                RegexOptions.Singleline |
                RegexOptions.IgnorePatternWhitespace);
        }

        public UsaAddressParseResult Parse(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                input = input.Replace(",", " ");
                var match = addressRegex.Match(input);
                if (match.Success)
                {
                    var extracted = GetApplicableFields(match);
                    return new UsaAddressParseResult(Normalize(extracted));
                }
            }

            return null;
        }

        private static Dictionary<string, string> Normalize(Dictionary<string, string> extracted)
        {
            var normalized = new Dictionary<string, string>();

            foreach (var pair in extracted)
            {
                var key = pair.Key;
                var value = (pair.Value ?? String.Empty).Trim();

                normalized[key] = value;
            }

            return normalized;
        }

        private static Dictionary<string, string> GetApplicableFields(Match match)
        {
            var applicable = new Dictionary<string, string>();

            foreach (var field in addressRegex.GetGroupNames())
            {
                if (fields.Contains(field))
                {
                    if (match.Groups[field].Success)
                    {
                        applicable[field] = match.Groups[field].Value;
                    }
                }
            }

            return applicable;
        }
    }
}
