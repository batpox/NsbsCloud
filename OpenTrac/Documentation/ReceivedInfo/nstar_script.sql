USE [NStar]
GO
/****** Object:  Table [dbo].[AP_BATCH_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AP_BATCH_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_PAYMENT_BATCH_NUMBER] [numeric](7, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[CREATE_DATE] [datetime] NULL,
	[CREATE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[PRINT_DATE] [datetime] NULL,
	[PRINT_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[RELEASE_DATE] [datetime] NULL,
	[RELEASE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[RE_RELEASE_DATE] [datetime] NULL,
	[RE_RELEASE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[PROCESSOR_COUNT] [numeric](4, 0) NULL,
	[FREIGHT_COUNT] [numeric](4, 0) NULL,
	[SCRAP_COUNT] [numeric](4, 0) NULL,
	[PROCESSOR_TOTAL_SUM] [numeric](13, 2) NULL,
	[FREIGHT_TOTAL_SUM] [numeric](13, 2) NULL,
	[SCRAP_TOTAL_SUM] [numeric](13, 2) NULL,
	[DISCOUNT_DATE] [datetime] NULL,
	[DUE_DATE] [datetime] NULL,
	[TOTAL_GROSS_AMOUNT] [numeric](13, 2) NULL,
	[TOTAL_TAX_AMOUNT] [numeric](13, 2) NULL,
	[TOTAL_DISCOUNT_AMOUNT] [numeric](13, 2) NULL,
	[TOTAL_NET_AMOUNT] [numeric](13, 2) NULL,
	[TOTAL_SURCHARGE_AMOUNT] [numeric](13, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AP_DETAIL_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AP_DETAIL_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[PAYMENT_TYPE_CODE] [nvarchar](10) NULL,
	[TRACKSYS_AP_NUMBER] [numeric](7, 0) NULL,
	[VENDOR_ID] [nvarchar](12) NULL,
	[VENDOR_INVOICE_NUMBER] [nvarchar](16) NULL,
	[VENDOR_INVOICE_LINE] [numeric](3, 0) NULL,
	[PURCHASE_ORDER_NUMBER] [nvarchar](10) NULL,
	[PURCHASE_ORDER_LINE] [numeric](3, 0) NULL,
	[QUANTITY] [numeric](9, 3) NULL,
	[UOM_CODE] [nvarchar](8) NULL,
	[GROSS_TOTAL] [numeric](13, 2) NULL,
	[DISCOUNT_AMOUNT] [numeric](13, 2) NULL,
	[TOTAL_TAX] [numeric](13, 2) NULL,
	[TAX_CODE] [nvarchar](10) NULL,
	[NET_TOTAL] [numeric](13, 2) NULL,
	[RECORD_DATE] [datetime] NULL,
	[DISCOUNT_DUE_DATE] [datetime] NULL,
	[FULL_DUE_DATE] [datetime] NULL,
	[GL_EXPENSE_CODE] [nvarchar](20) NULL,
	[FISCAL_YEAR] [numeric](4, 0) NULL,
	[FISCAL_MONTH] [numeric](2, 0) NULL,
	[INVOICE_DATE] [datetime] NULL,
	[SURCHARGE_AMOUNT] [numeric](13, 2) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[BILL_OF_LADING] [nvarchar](22) NULL,
	[IMPETUS_CODE] [nvarchar](7) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AR_CREDIT_DEBIT_GL_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AR_CREDIT_DEBIT_GL_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[AR_MEMO_LINE_NUMBER] [nvarchar](3) NULL,
	[REVENUE_TYPE_CODE] [nvarchar](10) NULL,
	[CREDIT_VALUE] [numeric](13, 2) NULL,
	[DEBIT_VALUE] [numeric](13, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AR_CREDIT_DEBIT_HEADER_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AR_CREDIT_DEBIT_HEADER_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_AR_MEMO_NUMBER] [nvarchar](7) NULL,
	[MEMO_TYPE] [nvarchar](7) NULL,
	[CLAIM_NUMBER] [nvarchar](12) NULL,
	[DATE_RELEASED] [datetime] NULL,
	[FINANSYS_BILLTO_KEY] [nvarchar](10) NULL,
	[FINANSYS_SHIPTO_KEY] [nvarchar](10) NULL,
	[MEMO_WEIGHT_LBS_SUM] [numeric](9, 0) NULL,
	[MEMO_PIECES_SUM] [numeric](9, 0) NULL,
	[MEMO_PRICE_SUM] [numeric](15, 2) NULL,
	[CUST_REFERENCE_NO] [nvarchar](20) NULL,
	[FINANSYS_REFERENCE_NO] [nvarchar](20) NULL,
	[HEAD_INT_COMMENT] [nvarchar](200) NULL,
	[DIST_PRINT_COMMENT] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AR_CREDIT_DEBIT_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AR_CREDIT_DEBIT_LINE_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[AR_MEMO_LINE_NUMBER] [numeric](3, 0) NULL,
	[MEMO_WEIGHT_LBS] [numeric](9, 0) NULL,
	[MEMO_PIECES] [numeric](4, 0) NULL,
	[MEMO_PRICE] [numeric](15, 2) NULL,
	[REASON_CODE] [nvarchar](10) NULL,
	[TRACKSYS_INVOICE_NUMBER] [numeric](7, 0) NULL,
	[INVOICE_LINE_NUMBER] [numeric](3, 0) NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[SHIPPED_WEIGHT] [numeric](9, 0) NULL,
	[PIECES] [numeric](9, 0) NULL,
	[GROSS_EXTENDED_PRICE] [numeric](15, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COMMERCIAL_INVOICE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMERCIAL_INVOICE_TX](
	[SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[COMBINED_INVOICE_NUMBER] [numeric](10, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[INVOICE_DATE] [datetime] NULL,
	[FISCAL_YEAR] [nvarchar](4) NULL,
	[FISCAL_MONTH] [nvarchar](2) NULL,
	[TRACKSYS_SALESORD_NUMBER] [numeric](18, 0) NULL,
	[REVISION] [numeric](18, 0) NULL,
	[CUSTOMER_NAME] [nvarchar](50) NULL,
	[FINANSYS_BILLTO_KEY] [numeric](20, 0) NULL,
	[BILLTO_NAME] [nvarchar](50) NULL,
	[BILLTO_ADDR_LINE1] [nvarchar](50) NULL,
	[BILLTO_ADDR_LINE2] [nvarchar](50) NULL,
	[BILLTO_CITY_TEXT] [nvarchar](50) NULL,
	[BILLTO_REGION_CODE] [nvarchar](2) NULL,
	[BILLTO_POSTAL_CODE] [nvarchar](15) NULL,
	[BILLTO_COUNTRY_TEXT] [nvarchar](50) NULL,
	[FINANSYS_SHIPTO_KEY] [numeric](20, 0) NULL,
	[SHIPTO_NAME] [nvarchar](50) NULL,
	[SHIPTO_ADDR_LINE_1] [nvarchar](50) NULL,
	[SHIPTO_ADDR_LINE_2] [nvarchar](50) NULL,
	[SHIPTO_CITY_TEXT] [nvarchar](50) NULL,
	[SHIPTO_REGION_CODE] [nvarchar](2) NULL,
	[SHIPTO_POSTAL_CODE] [nvarchar](15) NULL,
	[SHIPTO_COUNTRY_TEXT] [nvarchar](50) NULL,
	[HD_NET_EXTENDED_PRICE] [numeric](20, 2) NULL,
	[HD_TAX1_NAME] [nvarchar](50) NULL,
	[HD_TAX1_PERCENT_RATE] [numeric](20, 2) NULL,
	[HD_TAX2_NAME] [nvarchar](50) NULL,
	[HD_TAX2_PERCENT_RATE] [numeric](20, 2) NULL,
	[HD_TAX1_PRICE] [numeric](20, 2) NULL,
	[HD_TAX2_PRICE] [numeric](20, 2) NULL,
	[HD_GRAND_TOTAL_PRICE] [numeric](20, 2) NULL,
	[HD_CURRENCY_CODE] [nvarchar](50) NULL,
	[HD_ALT_CURR_EX_RATE] [numeric](20, 2) NULL,
	[HD_ALT_CURRENCY_CODE] [nvarchar](50) NULL,
	[HD_ALT_NET_EXTENDED_PRICE] [numeric](20, 2) NULL,
	[HD_ALT_TAX1_PRICE] [numeric](20, 2) NULL,
	[HD_ALT_TAX2_PRICE] [numeric](20, 2) NULL,
	[HD_ALT_GRAND_TOTAL_PRICE] [numeric](20, 2) NULL,
	[LINE_NUMBER] [numeric](18, 0) NULL,
	[PRODUCT_TYPE_CODE] [nvarchar](50) NULL,
	[TRACKSYS_PART_NUMBER] [nvarchar](50) NULL,
	[TRACKSYS_PART_REVISION] [numeric](18, 0) NULL,
	[LN_CUST_PART_NUMBER] [nvarchar](50) NULL,
	[LN_CUST_PO_NUMBER] [nvarchar](50) NULL,
	[LN_PIECE_WEIGHT] [numeric](15, 4) NULL,
	[LN_PIECE_WEIGHT_UMCODE] [nvarchar](50) NULL,
	[LN_COMMERCIAL_INVOICE_QTY] [numeric](16, 2) NULL,
	[LN_QUANTITY_UM] [nvarchar](50) NULL,
	[LN_LBS] [numeric](15, 4) NULL,
	[LN_NET_UNIT_PRICE] [numeric](20, 2) NULL,
	[LN_PRICE_UM_TEXT] [nvarchar](50) NULL,
	[LN_EXTENDED_PRICE] [numeric](20, 2) NULL,
	[LN_ALT_CURRENCY_CODE] [nvarchar](50) NULL,
	[LN_ALT_UNIT_PRICE] [numeric](20, 2) NULL,
	[LN_ALT_PRICE_UOM] [nvarchar](50) NULL,
	[LN_ALT_EXTENDED_PRICE] [numeric](20, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTACT_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACT_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[SERVICE_CODE] [nvarchar](20) NULL,
	[CONTACT_RECORD_KEY] [nvarchar](10) NULL,
	[ACTION_CODE] [nvarchar](8) NULL,
	[FORMAT_CODE] [nvarchar](20) NULL,
	[NAME] [nvarchar](50) NULL,
	[PHONE_NUMBER] [nvarchar](20) NULL,
	[EMAIL_ADDR] [nvarchar](50) NULL,
	[ADDR_LINE_1] [nvarchar](32) NULL,
	[ADDR_LINE_2] [nvarchar](32) NULL,
	[COUNTRY_CODE] [nvarchar](5) NULL,
	[COUNTRY_TEXT] [nvarchar](32) NULL,
	[CITY_TEXT] [nvarchar](32) NULL,
	[REGION_CODE] [nvarchar](2) NULL,
	[REGION_TEXT] [nvarchar](32) NULL,
	[POSTAL_CODE] [nvarchar](10) NULL,
	[URL] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMER_MASTER_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER_MASTER_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[CUSTOMER_PLANT_DUNS] [nvarchar](9) NULL,
	[BILL_TO_RECORD_KEY] [nvarchar](10) NULL,
	[SHIP_TO_RECORD_KEY] [nvarchar](10) NULL,
	[ACTIVE_FLAG] [nchar](1) NULL,
	[UNITS_CODE] [nvarchar](1) NULL,
	[INSIDE_SALES_TEAM_TEXT] [nvarchar](20) NULL,
	[SALES_REGION] [nvarchar](15) NULL,
	[PAYMENT_TERMS_CODE] [nvarchar](10) NULL,
	[HOLD_FOR_CUST_RELEASE_FLAG] [nchar](1) NULL,
	[INVOICE_VIA_EDI_FLAG] [nchar](1) NULL,
	[INVOICE_VIA_MAIL_FLAG] [nchar](1) NULL,
	[INVOICE_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[INVOICE_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[TEST_REPORT_EDI_FLAG] [nchar](1) NULL,
	[TEST_REPORT_MAIL_FLAG] [nchar](1) NULL,
	[TEST_REPORT_EMAIL_FLAG] [nchar](1) NULL,
	[TEST_REPORT_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[ORDER_ACK_VIA_EDI_FLAG] [nchar](1) NULL,
	[ORDER_ACK_VIA_MAIL_FLAG] [nchar](1) NULL,
	[ORDER_ACK_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[ORDER_ACK_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[SHIP_NOTICE_VIA_EDI_FLAG] [nchar](1) NULL,
	[SHIP_NOTICE_VIA_MAIL_FLAG] [nchar](1) NULL,
	[SHIP_NOTICE_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[SHIP_NOTICE_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[SIC_CODE] [nvarchar](7) NULL,
	[FEDERAL_TAX_ID] [nvarchar](11) NULL,
	[TAX_EXEMPT_CERTIFICATE] [nvarchar](15) NULL,
	[CUSTOMER_NOTE_1] [nvarchar](60) NULL,
	[CUSTOMER_NOTE_2] [nvarchar](60) NULL,
	[CREDIT_STATUS_CODE] [nvarchar](1) NULL,
	[SHIP_MODE_CODE] [nvarchar](10) NULL,
	[FREIGHT_PAYMENT] [nvarchar](10) NULL,
	[PREFERRED_CARRIER] [nvarchar](20) NULL,
	[FREIGHT_CONTRACT] [nvarchar](18) NULL,
	[DELIVERY_ROUTE] [nvarchar](35) NULL,
	[RECEIVING_HOURS] [nvarchar](15) NULL,
	[SHIPPING_NOTE_1] [nvarchar](100) NULL,
	[SHIPPING_NOTE_2] [nvarchar](100) NULL,
	[SHIPPING_NOTE_3] [nvarchar](100) NULL,
	[SHIPPING_NOTE_4] [nvarchar](100) NULL,
	[ACCOUNT_TYPE_CODE] [nvarchar](1) NULL,
	[OUTSIDE_SALES_TEAM_TEXT] [nvarchar](20) NULL,
	[SHIPTO_DUNS] [nvarchar](9) NULL,
	[HOLD_INVOICE_FLAG] [nchar](1) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMER_PART_PRICING_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER_PART_PRICING_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[PRICE_RAW_MATERIAL] [numeric](9, 4) NULL,
	[PRICE_RAW_MATERIAL_DESC] [nvarchar](100) NULL,
	[PRICE_PACKAGING] [numeric](9, 4) NULL,
	[PRICE_PACKAGING_DESC] [nvarchar](100) NULL,
	[PRICE_STORAGE_HANDLING] [numeric](9, 4) NULL,
	[PRICE_STORAGE_HANDLING_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_CUST] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_CUST_DESC] [nvarchar](100) NULL,
	[PRICE_ADMIN] [numeric](9, 4) NULL,
	[PRICE_ADMIN_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_PROC_1] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_1] [nvarchar](100) NULL,
	[PRICE_PROCESSING_1] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_1] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_1] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_2] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_2] [nvarchar](100) NULL,
	[PRICE_PROCESSING_2] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_2] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_2] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_3] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_3] [nvarchar](100) NULL,
	[PRICE_PROCESSING_3] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_3] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_3] [numeric](6, 2) NULL,
	[PRICE_UOM] [nvarchar](8) NULL,
	[PRICE_GROSS_UNIT] [numeric](9, 4) NULL,
	[PRICE_CWT] [numeric](9, 2) NULL,
	[PRICE_START_DATE] [datetime] NULL,
	[PRICE_END_DATE] [datetime] NULL,
	[PRICE_CREATED_BY] [nvarchar](20) NULL,
	[PRICE_STATUS] [nvarchar](20) NULL,
	[PRICE_ENTERED_DATE] [datetime] NULL,
	[PRICE_DEACTIVATED_DATE] [datetime] NULL,
	[CUSTOMER_PO] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMER_PART_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER_PART_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[CUST_PART_TYPE_CODE] [nvarchar](8) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[CUST_CORP_ORG_NAME] [nvarchar](50) NULL,
	[CUST_CORP_ORG_ABBR] [nvarchar](12) NULL,
	[CUST_CORP_ORG_DUNS] [nvarchar](9) NULL,
	[CUST_PART_NUMBER] [nvarchar](32) NULL,
	[CUST_PART_DESCRIPTION] [nvarchar](32) NULL,
	[CUST_DESCRIPTION] [nvarchar](32) NULL,
	[CUST_END_USE] [nvarchar](32) NULL,
	[MIPS_SUBPRODUCT] [nvarchar](20) NULL,
	[PRODUCT_TYPE_CODE] [nvarchar](10) NULL,
	[CUST_SPEC_CODE] [nvarchar](10) NULL,
	[CUST_SPEC_TEXT] [nvarchar](30) NULL,
	[CUST_SPEC_SYSTEM_CODE] [nvarchar](10) NULL,
	[DESCRIPTION_LINE_1] [nvarchar](60) NULL,
	[DESCRIPTION_LINE_2] [nvarchar](60) NULL,
	[DESCRIPTION_LINE_3] [nvarchar](60) NULL,
	[OIL_TYPE_CODE] [nvarchar](10) NULL,
	[SPECIAL_ORDER_QUALITY_CODE] [nvarchar](4) NULL,
	[SCALE_BREAKER_FLAG] [nchar](1) NULL,
	[SURFACE_FINISH_CODE] [nvarchar](4) NULL,
	[FORMING_SPEC_CODE] [nvarchar](10) NULL,
	[SEED_MILLSYS_PART_NUMBER] [nvarchar](30) NULL,
	[SEED_TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[SEED_TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[GAUGE] [numeric](11, 4) NULL,
	[GAUGE_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[GAUGE_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[COIL_OUTER_DIAM_MIN] [numeric](6, 2) NULL,
	[COIL_OUTER_DIAM_MAX] [numeric](6, 2) NULL,
	[WEIGHT_MIN] [numeric](5, 0) NULL,
	[WEIGHT_MAX] [numeric](5, 0) NULL,
	[DIMENSION_TYPE_CODE] [nvarchar](5) NULL,
	[WIDTH] [numeric](11, 4) NULL,
	[WIDTH_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[WIDTH_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[LENGTH] [numeric](11, 4) NULL,
	[LENGTH_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[LENGTH_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[SECTION_CODE] [nvarchar](3) NULL,
	[PITCH] [numeric](11, 4) NULL,
	[COIL_INNER_DIAM_PREF] [numeric](6, 2) NULL,
	[COIL_INNER_DIAM_MIN] [numeric](6, 2) NULL,
	[COIL_INNER_DIAM_MAX] [numeric](6, 2) NULL,
	[WEIGHT_PREF] [numeric](5, 0) NULL,
	[WEIGHT_MAX_PACKAGE] [numeric](5, 0) NULL,
	[GALV_COAT_TOLR_TOP_MIN] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_TOP_MAX] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_BOT_MIN] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_BOT_MAX] [numeric](6, 3) NULL,
	[OIL_LEVEL_CODE] [nvarchar](10) NULL,
	[EDGE_CODE] [nvarchar](4) NULL,
	[TEXTURE_PATTERN_CODE] [nvarchar](10) NULL,
	[EMBOSS_PATTERN_CODE] [nvarchar](10) NULL,
	[FLATNESS_MAX] [nvarchar](16) NULL,
	[DIAGONAL_MAX] [nvarchar](16) NULL,
	[GAUGE_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TYPE_CODE] [nvarchar](10) NULL,
	[WIDTH_UMCODE] [nvarchar](8) NULL,
	[WIDTH_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[WIDTH_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[LENGTH_UMCODE] [nvarchar](8) NULL,
	[LENGTH_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[LENGTH_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[PITCH_UMCODE] [nvarchar](8) NULL,
	[DENSITY_FACTOR] [numeric](7, 5) NULL,
	[COIL_INNER_DIAM_PREF_UMCODE] [nvarchar](8) NULL,
	[COIL_INNER_DIAM_MIN_UMCODE] [nvarchar](8) NULL,
	[COIL_INNER_DIAM_MAX_UMCODE] [nvarchar](8) NULL,
	[COIL_OUTER_DIAM_MIN_UMCODE] [nvarchar](8) NULL,
	[COIL_OUTER_DIAM_MAX_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_PREF_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MIN_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MAX_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MAX_PACKAGE_UMCODE] [nvarchar](8) NULL,
	[TEST_CERT_REQUIRED_FLAG] [nchar](1) NULL,
	[PACKAGING_INSTR_CODE] [nvarchar](8) NULL,
	[MARKING_INSTR_CODE] [nvarchar](8) NULL,
	[LOADING_INSTR_CODE] [nvarchar](8) NULL,
	[INSPECTION_INSTR_LINE_1] [nvarchar](50) NULL,
	[INSPECTION_INSTR_LINE_2] [nvarchar](50) NULL,
	[GALV_INTERNAL_EXTERNAL] [nvarchar](1) NULL,
	[COATING_TYPE_CODE] [nvarchar](8) NULL,
	[COATING_WEIGHT_CODE] [nvarchar](8) NULL,
	[DIFF_COATING_WEIGHT_TOP_CODE] [nvarchar](8) NULL,
	[DIFF_COATING_WEIGHT_BOT_CODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_TOP_MIN_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_TOP_MAX_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_BOT_MIN_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_BOT_MAX_UMCODE] [nvarchar](8) NULL,
	[CHEM_TREATMENT] [nvarchar](1) NULL,
	[TENSION_LEVEL_ELONG] [numeric](6, 2) NULL,
	[TENSION_LEVEL_ELONG_UMCODE] [nvarchar](8) NULL,
	[SPANGLE_CODE] [nvarchar](1) NULL,
	[GALV_STENCIL_CODE] [nvarchar](8) NULL,
	[PAINT_VENDOR_NAME] [nvarchar](12) NULL,
	[PAINT_SYSTEM] [nvarchar](12) NULL,
	[GENERIC_PAINT_NAME] [nvarchar](12) NULL,
	[TOPSIDE_PRIMER_NUMBER] [nvarchar](20) NULL,
	[BACKSIDE_PRIMER_NUMBER] [nvarchar](20) NULL,
	[FINISH_COAT_COLOR_NUMBER] [nvarchar](20) NULL,
	[FINISH_COAT_COLOR_NAME] [nvarchar](20) NULL,
	[BACKER_NUMBER] [nvarchar](20) NULL,
	[PAINT_STENCIL_CODE] [nvarchar](8) NULL,
	[PAINT_TENSION_LEVEL_FLAG] [nchar](1) NULL,
	[PIECE_WEIGHT] [numeric](11, 4) NULL,
	[PIECE_WEIGHT_UMCODE] [nvarchar](8) NULL,
	[PHYS_PROPERTY_DESC_1] [nvarchar](100) NULL,
	[PHYS_PROPERTY_DESC_2] [nvarchar](100) NULL,
	[EFFECTIVE_DATE] [datetime] NULL,
	[EXPIRATION_DATE] [datetime] NULL,
	[PRICE_RAW_MATERIAL] [numeric](9, 4) NULL,
	[PRICE_RAW_MATERIAL_DESC] [nvarchar](100) NULL,
	[PRICE_PACKAGING] [numeric](9, 4) NULL,
	[PRICE_PACKAGING_DESC] [nvarchar](100) NULL,
	[PRICE_STORAGE_HANDLING] [numeric](9, 4) NULL,
	[PRICE_STORAGE_HANDLING_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_CUST] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_CUST_DESC] [nvarchar](100) NULL,
	[PRICE_ADMIN] [numeric](9, 4) NULL,
	[PRICE_ADMIN_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_PROC_1] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_1] [nvarchar](100) NULL,
	[PRICE_PROCESSING_1] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_1] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_1] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_2] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_2] [nvarchar](100) NULL,
	[PRICE_PROCESSING_2] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_2] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_2] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_3] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_3] [nvarchar](100) NULL,
	[PRICE_PROCESSING_3] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_3] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_3] [numeric](6, 2) NULL,
	[PRICE_UOM] [nvarchar](8) NULL,
	[PRICE_GROSS_UNIT] [numeric](9, 4) NULL,
	[PRICE_CWT] [numeric](9, 2) NULL,
	[LENGTH_FEET] [numeric](11, 4) NULL,
	[GRADE] [nvarchar](8) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IN_BOL_HEAD]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IN_BOL_HEAD](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[OP_SENDER_ID] [nvarchar](9) NULL,
	[BILL_OF_LADING] [nvarchar](22) NULL,
	[SHIP_DATE] [datetime] NULL,
	[SCAC] [nvarchar](4) NULL,
	[TRANSPORT_MODE] [nvarchar](4) NULL,
	[NET_LOAD_WEIGHT] [numeric](13, 4) NULL,
	[CONTRACT_NUMBER] [nvarchar](16) NULL,
	[VEHICLE_ID] [nvarchar](12) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IN_BOL_LINE]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IN_BOL_LINE](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[OP_SENDER_ID] [nvarchar](9) NOT NULL,
	[BILL_OF_LADING] [nvarchar](22) NOT NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NOT NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NOT NULL,
	[SALESORD_NUMBER] [numeric](7, 0) NULL,
	[SALESORD_LINE_NUMBER] [numeric](3, 0) NULL,
	[BILLTO_RECORD_KEY] [nvarchar](10) NULL,
	[SHIPTO_RECORD_KEY] [nvarchar](10) NULL,
	[CURRENT_ITEM_WEIGHT] [numeric](18, 0) NULL,
	[WIDTH] [numeric](11, 4) NULL,
	[GAUGE] [numeric](11, 4) NULL,
	[HEAT_NO] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVOICE_BATCH_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICE_BATCH_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_INVOICE_BATCH_NUMBER] [numeric](7, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[INVOICE_COUNT] [numeric](4, 0) NULL,
	[NET_EXTENDED_PRICE_SUM_SUM] [numeric](13, 2) NULL,
	[FREIGHT_EXTENDED_PRICE_SUM_SUM] [numeric](13, 2) NULL,
	[TOTAL_TAX_SUM] [numeric](13, 2) NULL,
	[FULL_INVOICE_TOTAL_SUM] [numeric](13, 2) NULL,
	[DISCOUNT_INVOICE_TOTAL_SUM] [numeric](13, 2) NULL,
	[CREATE_DATE] [datetime] NULL,
	[CREATE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[RELEASE_DATE] [datetime] NULL,
	[RELEASE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[PRINT_DATE] [datetime] NULL,
	[PRINT_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[DISTRIBUTE_DATE] [datetime] NULL,
	[DISTRIBUTE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[RE_RELEASE_DATE] [datetime] NULL,
	[RE_RELEASE_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[RE_DISTRIBUTE_DATE] [datetime] NULL,
	[RE_DISTRIBUTE_ACCOUNT_LOGIN] [nvarchar](15) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVOICE_GL_ENTRY_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICE_GL_ENTRY_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_INVOICE_NUMBER] [numeric](7, 0) NULL,
	[REVENUE_TYPE_CODE] [nvarchar](10) NULL,
	[GL_ACCOUNT_NUMBER] [nvarchar](20) NULL,
	[CREDIT_VALUE] [numeric](13, 2) NULL,
	[DEBIT_VALUE] [numeric](13, 2) NULL,
	[TRACKSYS_INVC_LINE] [numeric](3, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVOICE_HEAD_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICE_HEAD_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_INVOICE_NUMBER] [numeric](7, 0) NULL,
	[SHIPMENT_EDI_ID] [numeric](10, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[INVOICE_DATE] [datetime] NULL,
	[FISCAL_YEAR] [numeric](4, 0) NULL,
	[FISCAL_MONTH] [numeric](2, 0) NULL,
	[RELEASE_DATE] [datetime] NULL,
	[TRACKSYS_INVOICE_BATCH_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_SALESORD_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_SALESORD_REVISION] [numeric](3, 0) NULL,
	[SALESORD_LINE_NUMBER] [numeric](3, 0) NULL,
	[SALESORD_ENTRY_DATE] [datetime] NULL,
	[INSIDE_SALES_TEAM_TEXT] [nvarchar](20) NULL,
	[OUTSIDE_SALES_TEAM_TEXT] [nvarchar](20) NULL,
	[PYMT_TERMS_DESCRIPTION] [nvarchar](30) NULL,
	[NET_DUE_DAYS] [numeric](3, 0) NULL,
	[DISCOUNT_DUE_DAYS] [numeric](3, 0) NULL,
	[DISCOUNT_PERCENT] [numeric](7, 4) NULL,
	[DIMENSION_TYPE_CODE] [nvarchar](5) NULL,
	[FINANSYS_BILLTO_KEY] [nvarchar](10) NULL,
	[BILLTO_NAME] [nvarchar](50) NULL,
	[BILLTO_ADDR_LINE_1] [nvarchar](32) NULL,
	[BILLTO_ADDR_LINE_2] [nvarchar](32) NULL,
	[BILLTO_CITY_TEXT] [nvarchar](32) NULL,
	[BILLTO_REGION_CODE] [nvarchar](2) NULL,
	[BILLTO_POSTAL_CODE] [nvarchar](10) NULL,
	[BILLTO_COUNTRY_TEXT] [nvarchar](32) NULL,
	[FINANSYS_SHIPTO_KEY] [nvarchar](10) NULL,
	[SHIPTO_NAME] [nvarchar](50) NULL,
	[SHIPTO_ADDR_LINE_1] [nvarchar](32) NULL,
	[SHIPTO_ADDR_LINE_2] [nvarchar](32) NULL,
	[SHIPTO_CITY_TEXT] [nvarchar](32) NULL,
	[SHIPTO_REGION_CODE] [nvarchar](2) NULL,
	[SHIPTO_POSTAL_CODE] [nvarchar](10) NULL,
	[SHIPTO_COUNTRY_TEXT] [nvarchar](32) NULL,
	[CUST_PO_NUMBER] [nvarchar](10) NULL,
	[FEDERAL_TAX_ID] [nvarchar](11) NULL,
	[TAX_EXEMPT_CERTIFICATE] [nvarchar](15) NULL,
	[OP_REGISTRATION_NO] [numeric](22, 0) NULL,
	[SHIPPER_ORG_DUNS] [nvarchar](9) NULL,
	[BILL_OF_LADING_NUMBER] [nvarchar](22) NULL,
	[SHIP_DATE] [datetime] NULL,
	[TRANSPORT_MODE_CODE] [nvarchar](4) NULL,
	[VEHICLE_ID] [nvarchar](12) NULL,
	[FOB_POINT] [nvarchar](16) NULL,
	[FREIGHT_PAYMENT_CODE] [nvarchar](10) NULL,
	[SHIPPED_WEIGHT_SUM] [numeric](11, 0) NULL,
	[NET_EXTENDED_PRICE_SUM] [numeric](13, 2) NULL,
	[FREIGHT_EXTENDED_PRICE_SUM] [numeric](13, 2) NULL,
	[TAX_CODE] [nvarchar](10) NULL,
	[GROSS_EXTENDED_PRICE_SUM] [numeric](13, 2) NULL,
	[TOTAL_TAX] [numeric](13, 2) NULL,
	[FULL_INVOICE_TOTAL] [numeric](13, 2) NULL,
	[DISCOUNT_AMOUNT] [numeric](11, 2) NULL,
	[DISCOUNT_DUE_DATE] [datetime] NULL,
	[FULL_DUE_DATE] [datetime] NULL,
	[DISCOUNT_INVOICE_TOTAL] [numeric](13, 2) NULL,
	[SURCHARGE_EXTENDED_PRICE_SUM] [numeric](13, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVOICE_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVOICE_LINE_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[TRACKSYS_INVOICE_NUMBER] [numeric](7, 0) NULL,
	[INVOICE_LINE_NUMBER] [numeric](3, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[MIPS_SUBPRODUCT] [nvarchar](20) NULL,
	[PRODUCT_TYPE_CODE] [nvarchar](10) NULL,
	[TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[CUST_PART_NUMBER] [nvarchar](32) NULL,
	[CUST_REQUIRED_SPECSET_TEXT] [nvarchar](30) NULL,
	[PART_DESCRIPTION_LINE_1] [nvarchar](60) NULL,
	[MEASUREMENT_SYSTEM_CODE] [nvarchar](1) NULL,
	[GAUGE_TYPE_CODE] [nvarchar](10) NULL,
	[ENGLISH_GAUGE] [numeric](11, 4) NULL,
	[ENGLISH_WIDTH] [numeric](11, 4) NULL,
	[ENGLISH_LENGTH] [numeric](11, 4) NULL,
	[METRIC_GAUGE] [numeric](11, 4) NULL,
	[METRIC_WIDTH] [numeric](11, 4) NULL,
	[METRIC_LENGTH] [numeric](11, 4) NULL,
	[INVOICING_COMMENT] [nvarchar](60) NULL,
	[MILL_ORG_CODE] [nvarchar](10) NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[HEAT_NUMBER] [nvarchar](10) NULL,
	[MATERIAL_CLASS_CODE] [nvarchar](4) NULL,
	[SHIPPED_WEIGHT] [numeric](9, 0) NULL,
	[PIECES] [numeric](4, 0) NULL,
	[LINEAL_FEET] [numeric](5, 0) NULL,
	[LINEAL_METERS] [numeric](5, 0) NULL,
	[METRIC_WEIGHT] [numeric](5, 0) NULL,
	[ORDERED_PRICE_UM] [nvarchar](8) NULL,
	[ORDERED_GROSS_UNIT_PRICE] [numeric](15, 4) NULL,
	[ORDERED_FREIGHT_UNIT_PRICE] [numeric](15, 4) NULL,
	[ORDERED_NET_UNIT_PRICE] [numeric](15, 4) NULL,
	[ORDERED_QUANTITY] [numeric](15, 4) NULL,
	[STANDARD_PRICE_UM] [nvarchar](8) NULL,
	[STANDARD_GROSS_UNIT_PRICE] [numeric](15, 4) NULL,
	[STANDARD_FREIGHT_UNIT_PRICE] [numeric](15, 4) NULL,
	[STANDARD_NET_UNIT_PRICE] [numeric](15, 4) NULL,
	[STANDARD_QUANTITY] [numeric](15, 4) NULL,
	[GROSS_EXTENDED_PRICE] [numeric](15, 4) NULL,
	[FREIGHT_EXTENDED_PRICE] [numeric](15, 4) NULL,
	[NET_EXTENDED_PRICE] [numeric](15, 4) NULL,
	[ORDERED_SURCHARGE_UNIT_PRICE] [numeric](15, 4) NULL,
	[STANDARD_SURCHARGE_UNIT_PRICE] [numeric](15, 4) NULL,
	[SURCHARGE_EXTENDED_PRICE] [numeric](15, 4) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_CHEMISTRY_RAW_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_CHEMISTRY_RAW_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[SAMPLE] [nvarchar](10) NULL,
	[HEAT_NO] [nvarchar](10) NULL,
	[MFG_PLANT_DUNS] [nvarchar](22) NULL,
	[SENDER_ID] [nvarchar](22) NULL,
	[RECEIVER_ID] [nvarchar](22) NULL,
	[CARBON] [nvarchar](10) NULL,
	[MANGANESE] [nvarchar](10) NULL,
	[PHOSPHOROUS] [nvarchar](10) NULL,
	[SULFUR] [nvarchar](10) NULL,
	[SILICON] [nvarchar](10) NULL,
	[COPPER] [nvarchar](10) NULL,
	[NICKEL] [nvarchar](10) NULL,
	[CHROMIUM] [nvarchar](10) NULL,
	[MOLYBDENUM] [nvarchar](10) NULL,
	[TIN] [nvarchar](10) NULL,
	[ALUMINUM] [nvarchar](10) NULL,
	[NITROGEN] [nvarchar](10) NULL,
	[VANADIUM] [nvarchar](10) NULL,
	[BORON] [nvarchar](10) NULL,
	[TITANIUM] [nvarchar](10) NULL,
	[COLUMBIUM] [nvarchar](10) NULL,
	[NIOBIUM] [nvarchar](10) NULL,
	[COBALT] [nvarchar](10) NULL,
	[LEAD] [nvarchar](10) NULL,
	[ARSENIC] [nvarchar](10) NULL,
	[ANTIMONY] [nvarchar](10) NULL,
	[TUNGSTEN] [nvarchar](10) NULL,
	[TANTALUM] [nvarchar](10) NULL,
	[ZIRCONIUM] [nvarchar](10) NULL,
	[SELENIUM] [nvarchar](10) NULL,
	[TELLURIUM] [nvarchar](10) NULL,
	[OXYGEN] [nvarchar](10) NULL,
	[HYDROGEN] [nvarchar](10) NULL,
	[GERMANIUM] [nvarchar](10) NULL,
	[CALCIUM] [nvarchar](10) NULL,
	[MAGNESIUM] [nvarchar](10) NULL,
	[BISMUTH] [nvarchar](10) NULL,
	[CERIUM] [nvarchar](10) NULL,
	[ZINC] [nvarchar](10) NULL,
	[OXYGEN_CODE] [nvarchar](4) NULL,
	[OTHER_CODE1] [nvarchar](4) NULL,
	[OTHER_PERCENT1] [nvarchar](10) NULL,
	[OTHER_CODE2] [nvarchar](4) NULL,
	[OTHER_VALUE2] [nvarchar](10) NULL,
	[PROCESSED_IND] [nvarchar](1) NULL,
	[MODIFIED_BY] [nvarchar](25) NULL,
	[DATE_TIMESTAMP] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_INVENTORY_RAW_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_INVENTORY_RAW_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[IB_BILL_OF_LADING] [nvarchar](22) NULL,
	[IB_SHIP_DATE] [datetime] NULL,
	[MFG_PLANT_DUNS] [nvarchar](22) NULL,
	[SENDER_ID] [nvarchar](22) NULL,
	[RECEIVER_ID] [nvarchar](22) NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NULL,
	[PREV_MATERIAL_ID] [nvarchar](16) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[PART_NUMBER] [nvarchar](32) NULL,
	[MATERIAL_STATUS] [nvarchar](4) NULL,
	[MAT_STATUS_UPDATE_DATE] [datetime] NULL,
	[RECEIVE_DATE] [datetime] NULL,
	[RECEIVE_TIME] [numeric](4, 0) NULL,
	[HEAT_NO] [nvarchar](10) NULL,
	[SHIP_ORDER_NO] [nvarchar](22) NULL,
	[SHIP_ORDER_ITEM] [nvarchar](4) NULL,
	[SHIP_ORDER_RELEASE] [nvarchar](6) NULL,
	[SP_PO_NO] [nvarchar](22) NULL,
	[SP_PO_RELEASE] [nvarchar](6) NULL,
	[SP_PO_DATE] [datetime] NULL,
	[SECT_SYMBOL_CODE] [nvarchar](4) NULL,
	[DIMENSION_CODE] [nvarchar](4) NULL,
	[DIMENSION1] [numeric](14, 4) NULL,
	[DIMENSION1_UOM] [nvarchar](5) NULL,
	[DIMENSION1_NN] [numeric](18, 0) NULL,
	[DIMENSION1_DD] [numeric](18, 0) NULL,
	[DIMENSION2] [numeric](14, 4) NULL,
	[DIMENSION2_UOM] [nvarchar](5) NULL,
	[DIMENSION2_NN] [numeric](18, 0) NULL,
	[DIMENSION2_DD] [numeric](18, 0) NULL,
	[DIMENSION3] [numeric](14, 4) NULL,
	[DIMENSION3_UOM] [nvarchar](5) NULL,
	[DIMENSION3_NN] [numeric](18, 0) NULL,
	[DIMENSION3_DD] [numeric](18, 0) NULL,
	[DIMENSION4] [numeric](14, 4) NULL,
	[DIMENSION4_UOM] [nvarchar](5) NULL,
	[DIMENSION4_NN] [numeric](18, 0) NULL,
	[DIMENSION4_DD] [numeric](18, 0) NULL,
	[LENGTH1] [numeric](18, 0) NULL,
	[LENGTH1_UOM] [nvarchar](5) NULL,
	[LENGTH1_NN] [numeric](18, 0) NULL,
	[LENGTH1_DD] [numeric](18, 0) NULL,
	[LENGTH2] [numeric](18, 0) NULL,
	[LENGTH2_UOM] [nvarchar](5) NULL,
	[LENGTH2_NN] [numeric](18, 0) NULL,
	[LENGTH2_DD] [numeric](18, 0) NULL,
	[QUANTITY1_UNIT] [nvarchar](4) NULL,
	[QUANTITY1] [numeric](18, 0) NULL,
	[QUANTITY2_UNIT] [nvarchar](4) NULL,
	[QUANTITY2] [numeric](18, 0) NULL,
	[RECEIVED_WEIGHT] [numeric](18, 0) NULL,
	[ASN_ITEM_WEIGHT] [numeric](18, 0) NULL,
	[CURRENT_ITEM_WEIGHT] [numeric](18, 0) NULL,
	[SCALE_WEIGHT_INDICATOR] [nvarchar](1) NULL,
	[COIL_INSIDE_DIAMETER] [numeric](18, 0) NULL,
	[COIL_ID_UOM] [nvarchar](5) NULL,
	[COIL_OUTSIDE_DIAMETER] [numeric](18, 0) NULL,
	[COIL_OD_UOM] [nvarchar](5) NULL,
	[MATERIAL_CLASS_CODE] [nvarchar](4) NULL,
	[EDGE_CODE] [nvarchar](4) NULL,
	[END_PROC] [nvarchar](4) NULL,
	[COMM_ITEM_STATUS] [nvarchar](4) NULL,
	[COMM_ITEM_STATUS_UPDATE] [datetime] NULL,
	[REAPPLY_DATE] [datetime] NULL,
	[MAINT_CHANGE] [nvarchar](4) NULL,
	[MAINT_CHANGE_DATE] [datetime] NULL,
	[PLATFORM_ID] [nvarchar](14) NULL,
	[ITEM_LOCATION] [nvarchar](12) NULL,
	[QA_CODE] [nvarchar](4) NULL,
	[QA_CODE_UPDATE_DATE] [datetime] NULL,
	[GRADE_CODE] [nvarchar](8) NULL,
	[TMW_FORMULA_CODE] [nvarchar](4) NULL,
	[TMW_K_VALUE] [numeric](18, 0) NULL,
	[SHIP_DATE] [datetime] NULL,
	[SHIP_BILL_OF_LADING] [nvarchar](22) NULL,
	[SHIP_INVOICE_NO] [nvarchar](16) NULL,
	[TRANSACTION_NO] [nvarchar](20) NULL,
	[TRANSACTION_TYPE] [nvarchar](10) NULL,
	[DAMAGE_COMMENT] [nvarchar](60) NULL,
	[DEST_MATERIAL_ID] [nvarchar](16) NULL,
	[COMMENT1] [nvarchar](60) NULL,
	[COMMENT2] [nvarchar](60) NULL,
	[RECEIVE_COMMENT] [nvarchar](60) NULL,
	[SCAN_ITEM] [nvarchar](4) NULL,
	[DAMAGE_FAULT1] [nvarchar](8) NULL,
	[DAMAGE_FAULT2] [nvarchar](8) NULL,
	[DAMAGE_FAULT3] [nvarchar](8) NULL,
	[DAMAGE_FAULT4] [nvarchar](8) NULL,
	[DAMAGE_FAULT5] [nvarchar](8) NULL,
	[DAMAGE_TYPE1] [nvarchar](8) NULL,
	[DAMAGE_TYPE2] [nvarchar](8) NULL,
	[DAMAGE_TYPE3] [nvarchar](8) NULL,
	[DAMAGE_TYPE4] [nvarchar](8) NULL,
	[DAMAGE_TYPE5] [nvarchar](8) NULL,
	[PROCESS1] [nvarchar](4) NULL,
	[PROCESS2] [nvarchar](4) NULL,
	[PROCESS3] [nvarchar](4) NULL,
	[PROCESS4] [nvarchar](4) NULL,
	[PROCESS5] [nvarchar](4) NULL,
	[MATERIAL_CHARGE] [nvarchar](15) NULL,
	[NEXT_PROCESS] [nvarchar](4) NULL,
	[PROCESS_DATE] [datetime] NULL,
	[PROCESS_TIME] [numeric](4, 0) NULL,
	[MODIFIED_BY] [nvarchar](25) NULL,
	[DATE_TIMESTAMP] [datetime] NULL,
	[CHARGE_TYPE] [nvarchar](1) NULL,
	[ACKR_REQ] [nvarchar](1) NULL,
	[PROCESS_SEQ] [numeric](18, 0) NULL,
	[PROCESSED_IND] [nvarchar](1) NULL,
	[CHARGEIN_DATE] [datetime] NULL,
	[CHARGEIN_TIME] [numeric](4, 0) NULL,
	[PRODUCT_UNIT_CODE] [nvarchar](8) NULL,
	[BREAK_SEQ] [numeric](18, 0) NULL,
	[MULT_SEQ] [numeric](18, 0) NULL,
	[HEAT_NO_SEQ] [nvarchar](3) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_LOAD_RAW_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_LOAD_RAW_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[BILL_OF_LADING] [nvarchar](22) NULL,
	[PACKING_SLIP] [nvarchar](22) NULL,
	[MFG_PLANT_DUNS] [nvarchar](22) NULL,
	[SENDER_ID] [nvarchar](22) NULL,
	[RECEIVER_ID] [nvarchar](22) NULL,
	[SHIP_TO_DUN] [nvarchar](22) NULL,
	[SHIP_TO_SUFFIX] [nvarchar](4) NULL,
	[SOLD_TO_DUN] [nvarchar](22) NULL,
	[SOLD_TO_SUFFIX] [nvarchar](4) NULL,
	[SHIP_FROM_DUN] [nvarchar](22) NULL,
	[SHIP_NATURE] [nvarchar](4) NULL,
	[TRANSPORT_MODE] [nvarchar](4) NULL,
	[VEHICLE_ID] [nvarchar](12) NULL,
	[APP_NO] [nvarchar](6) NULL,
	[APP_DATE] [datetime] NULL,
	[APP_TIME] [numeric](4, 0) NULL,
	[COMM_SYS_CODE] [nvarchar](4) NULL,
	[COMMENT1] [nvarchar](60) NULL,
	[COMMENT2] [nvarchar](60) NULL,
	[FREIGHT_CONTRACT_REF] [nvarchar](20) NULL,
	[FREIGHT_PAY_CODE] [nvarchar](4) NULL,
	[TARE_WEIGHT] [numeric](18, 0) NULL,
	[DUNNAGE] [numeric](18, 0) NULL,
	[LOAD_DATE] [datetime] NULL,
	[LOAD_VERIFIED] [nvarchar](4) NULL,
	[MASTER_LOAD_REF] [nvarchar](22) NULL,
	[MASTER_LOAD_WEIGHT] [numeric](18, 0) NULL,
	[QTY_SIDS_SP] [numeric](18, 0) NULL,
	[GROSS_LOAD_WEIGHT] [numeric](18, 0) NULL,
	[RAIL_CODE] [nvarchar](6) NULL,
	[RAILDESC] [nvarchar](60) NULL,
	[SCAC] [nvarchar](4) NULL,
	[SCACDESC] [nvarchar](60) NULL,
	[SHIP_DATE] [datetime] NULL,
	[SHIP_TIME] [numeric](4, 0) NULL,
	[NET_LOAD_WEIGHT] [numeric](18, 0) NULL,
	[THEO_LOAD_WEIGHT] [numeric](18, 0) NULL,
	[ITEM_COUNT] [numeric](18, 0) NULL,
	[PACKAGE_COUNT] [numeric](18, 0) NULL,
	[ENGLISH_METRIC] [nvarchar](4) NULL,
	[FOB_POINT] [nvarchar](16) NULL,
	[MATERIAL_TRANSFER] [nvarchar](4) NULL,
	[PASSWORD] [nvarchar](18) NULL,
	[SHIP_PAPER_PRINTED] [nvarchar](4) NULL,
	[TRANSACTION_KEY] [nvarchar](4) NULL,
	[SCAN_ITEM] [nvarchar](4) NULL,
	[MODIFIED_BY] [nvarchar](25) NULL,
	[DATE_TIMESTAMP] [datetime] NULL,
	[PROCESSED_IND] [nvarchar](1) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_METAL_CERT_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_METAL_CERT_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[INSERT_WHEN$SE] [datetime] NULL,
	[CERTIFIER_PLANT_DUNS] [nvarchar](22) NULL,
	[CERTIFIER_NAME] [nvarchar](35) NULL,
	[CERTIFICATION_ID] [nvarchar](22) NULL,
	[CERTIFICATION_WHEN$SE] [datetime] NULL,
	[BILL_OF_LADING_NBR] [nvarchar](22) NULL,
	[SHIPTO_PLANT_DUNS] [nvarchar](22) NULL,
	[SHIP_WHEN$DA] [datetime] NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[SLAB_NBR] [nvarchar](12) NULL,
	[HEAT_NBR] [nvarchar](10) NULL,
	[GAUGE] [numeric](18, 0) NULL,
	[GAUGE_UM] [nvarchar](5) NULL,
	[WIDTH] [numeric](18, 0) NULL,
	[WIDTH_UM] [nvarchar](5) NULL,
	[LENGTH] [numeric](18, 0) NULL,
	[LENGTH_UM] [nvarchar](5) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_METAL_TEST_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_METAL_TEST_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[INSERT_WHEN$SE] [datetime] NULL,
	[CERTIFIER_PLANT_DUNS] [nvarchar](22) NULL,
	[CERTIFICATION_ID] [nvarchar](22) NULL,
	[SP_MATERIAL_ID] [nvarchar](12) NULL,
	[OP_MATERIAL_ID] [nvarchar](16) NULL,
	[TEST_CLASS_CODE] [nvarchar](2) NULL,
	[STANDARDS_AGENCY_CODE] [nvarchar](2) NULL,
	[SAMPLE_STATUS_CODE] [nvarchar](2) NULL,
	[SAMPLE_SELECTION_CODE] [nvarchar](2) NULL,
	[SAMPLE_FREQUENCY_CODE] [nvarchar](9) NULL,
	[SAMPLE_FREQUENCY_UM] [nvarchar](2) NULL,
	[SAMPLE_DESC_CODE] [nvarchar](2) NULL,
	[SAMPLE_DIRECTION_CODE] [nvarchar](2) NULL,
	[SAMPLE_POSITION_CODE] [nvarchar](2) NULL,
	[TEST_CODE] [nvarchar](3) NULL,
	[RESULT_VALUE] [nvarchar](20) NULL,
	[RESULT_UM] [nvarchar](2) NULL,
	[RESULT_ATTRIBUTE_CODE] [nvarchar](2) NULL,
	[POSITION_2_CODE] [nvarchar](2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_NOTE_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_NOTE_LINE_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[INSERT_WHEN$SE] [datetime] NULL,
	[QUALIFIER] [nvarchar](3) NULL,
	[ORDINAL] [numeric](3, 0) NULL,
	[TEXT] [nvarchar](60) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_ORDER_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_ORDER_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[MILL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_STEEL_REQN_NUMBER] [numeric](7, 0) NULL,
	[MILLSYS_ORDER_NUMBER] [nvarchar](9) NULL,
	[MILLSYS_LINE_NUMBER] [nvarchar](4) NULL,
	[MILLSYS_PART_NUMBER] [nvarchar](30) NULL,
	[ORDER_WEIGHT] [numeric](9, 0) NULL,
	[SHIPPED_WEIGHT] [numeric](9, 0) NULL,
	[PROMISE_DATE] [datetime] NULL,
	[CREATE_DATE] [datetime] NULL,
	[CHANGE_DATE] [datetime] NULL,
	[STATUS_CODE] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_PART_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_PART_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[MILLSYS_PART_NUMBER] [nvarchar](30) NULL,
	[MILL_ORG_CODE] [nvarchar](10) NULL,
	[MILL_PART_TYPE_CODE] [nchar](4) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[CUST_PART_NUMBER] [nvarchar](32) NULL,
	[CUST_PART_DESCRIPTION] [nvarchar](32) NULL,
	[CUST_END_USE] [nvarchar](32) NULL,
	[MIPS_SUBPRODUCT] [nvarchar](20) NULL,
	[PRODUCT_TYPE_CODE] [nvarchar](10) NULL,
	[CUST_SPEC_TEXT] [nvarchar](30) NULL,
	[UNITS_CODE] [nvarchar](1) NULL,
	[PRODUCT_NAME] [nvarchar](30) NULL,
	[REVISION_DATE] [datetime] NULL,
	[DESCRIPTION_LINE_1] [nvarchar](60) NULL,
	[DESCRIPTION_LINE_2] [nvarchar](60) NULL,
	[DESCRIPTION_LINE_3] [nvarchar](60) NULL,
	[OIL_TYPE_CODE] [nvarchar](10) NULL,
	[SPECIAL_ORDER_QUALITY_CODE] [nvarchar](4) NULL,
	[SCALE_BREAKER_FLAG] [nchar](1) NULL,
	[SURFACE_FINISH_CODE] [nvarchar](4) NULL,
	[FORMING_SPEC_CODE] [nvarchar](10) NULL,
	[GAUGE] [numeric](11, 4) NULL,
	[GAUGE_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[GAUGE_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[COIL_OUTER_DIAM_MIN] [numeric](6, 2) NULL,
	[COIL_OUTER_DIAM_MAX] [numeric](6, 2) NULL,
	[WEIGHT_MIN] [numeric](5, 0) NULL,
	[WEIGHT_MAX] [numeric](5, 0) NULL,
	[DIMENSION_TYPE_CODE] [nvarchar](5) NULL,
	[WIDTH] [numeric](11, 4) NULL,
	[WIDTH_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[WIDTH_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[LENGTH] [numeric](11, 4) NULL,
	[LENGTH_TOLERANCE_MIN] [numeric](11, 4) NULL,
	[LENGTH_TOLERANCE_MAX] [numeric](11, 4) NULL,
	[SECTION_CODE] [nvarchar](3) NULL,
	[PITCH] [numeric](11, 4) NULL,
	[COIL_INNER_DIAM_PREF] [numeric](6, 2) NULL,
	[COIL_INNER_DIAM_MIN] [numeric](6, 2) NULL,
	[COIL_INNER_DIAM_MAX] [numeric](6, 2) NULL,
	[WEIGHT_PREF] [numeric](5, 0) NULL,
	[WEIGHT_MAX_PACKAGE] [numeric](5, 0) NULL,
	[GALV_COAT_TOLR_TOP_MIN] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_TOP_MAX] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_BOT_MIN] [numeric](6, 3) NULL,
	[GALV_COAT_TOLR_BOT_MAX] [numeric](6, 3) NULL,
	[OIL_LEVEL_CODE] [nvarchar](10) NULL,
	[EDGE_CODE] [nvarchar](4) NULL,
	[TEXTURE_PATTERN_CODE] [nvarchar](10) NULL,
	[EMBOSS_PATTERN_CODE] [nvarchar](10) NULL,
	[TENSION_LEVEL_FLAG] [nchar](1) NULL,
	[FLATNESS_MAX] [nvarchar](16) NULL,
	[DIAGONAL_MAX] [nvarchar](16) NULL,
	[GAUGE_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[GAUGE_TYPE_CODE] [nvarchar](10) NULL,
	[WIDTH_UMCODE] [nvarchar](8) NULL,
	[WIDTH_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[WIDTH_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[WIDTH_TYPE_CODE] [nvarchar](10) NULL,
	[LENGTH_UMCODE] [nvarchar](8) NULL,
	[LENGTH_TOLERANCE_MIN_UMCODE] [nvarchar](8) NULL,
	[LENGTH_TOLERANCE_MAX_UMCODE] [nvarchar](8) NULL,
	[PITCH_UMCODE] [nvarchar](8) NULL,
	[DENSITY_FACTOR] [numeric](7, 5) NULL,
	[COIL_INNER_DIAM_PREF_UMCODE] [nvarchar](8) NULL,
	[COIL_INNER_DIAM_MIN_UMCODE] [nvarchar](8) NULL,
	[COIL_INNER_DIAM_MAX_UMCODE] [nvarchar](8) NULL,
	[COIL_OUTER_DIAM_MIN_UMCODE] [nvarchar](8) NULL,
	[COIL_OUTER_DIAM_MAX_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_PREF_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MIN_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MAX_UMCODE] [nvarchar](8) NULL,
	[WEIGHT_MAX_PACKAGE_UMCODE] [nvarchar](8) NULL,
	[TEST_CERT_REQUIRED_FLAG] [nchar](1) NULL,
	[PACKAGING_INSTR_CODE] [nvarchar](8) NULL,
	[MARKING_INSTR_CODE] [nvarchar](8) NULL,
	[LOADING_INSTR_CODE] [nvarchar](8) NULL,
	[INSPECTION_INSTR_LINE_1] [nvarchar](50) NULL,
	[INSPECTION_INSTR_LINE_2] [nvarchar](50) NULL,
	[GALV_INTERNAL_EXTERNAL] [nvarchar](1) NULL,
	[COATING_TYPE_CODE] [nvarchar](8) NULL,
	[COATING_WEIGHT_CODE] [nvarchar](8) NULL,
	[DIFF_COATING_WEIGHT_TOP_CODE] [nvarchar](8) NULL,
	[DIFF_COATING_WEIGHT_BOT_CODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_TOP_MIN_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_TOP_MAX_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_BOT_MIN_UMCODE] [nvarchar](8) NULL,
	[GALV_COAT_TOLR_BOT_MAX_UMCODE] [nvarchar](8) NULL,
	[CHEM_TREATMENT] [nvarchar](1) NULL,
	[TENSION_LEVEL_ELONG] [numeric](6, 2) NULL,
	[TENSION_LEVEL_ELONG_UMCODE] [nvarchar](8) NULL,
	[SPANGLE_CODE] [nvarchar](1) NULL,
	[GALV_STENCIL_CODE] [nvarchar](8) NULL,
	[PIECE_WEIGHT] [numeric](11, 4) NULL,
	[PIECE_WEIGHT_UMCODE] [nvarchar](8) NULL,
	[PHYS_PROPERTY_DESC_1] [nvarchar](100) NULL,
	[PHYS_PROPERTY_DESC_2] [nvarchar](100) NULL,
	[COATING_AREA_CODE] [nvarchar](8) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_SHIP_ORDER_RAW_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_SHIP_ORDER_RAW_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[MFG_PLANT_DUNS] [nvarchar](22) NULL,
	[SENDER_ID] [nvarchar](22) NULL,
	[RECEIVER_ID] [nvarchar](22) NULL,
	[SHIP_ORDER_NO] [nvarchar](22) NULL,
	[SHIP_ORDER_ITEM] [nvarchar](4) NULL,
	[SHIP_ORDER_RELEASE] [nvarchar](4) NULL,
	[CUST_DUNS] [nvarchar](22) NULL,
	[CUST_SUFFIX] [nvarchar](4) NULL,
	[CUST_ORDER_NO] [nvarchar](22) NULL,
	[CUST_RELEASE_NO] [nvarchar](6) NULL,
	[CUST_ITEM] [nvarchar](4) NULL,
	[BAR_CODE_LINE1] [nvarchar](15) NULL,
	[BAR_CODE_LINE2] [nvarchar](15) NULL,
	[BAR_CODE_LINE3] [nvarchar](15) NULL,
	[BAR_CODE_LINE4] [nvarchar](15) NULL,
	[BAR_CODE_LINE5] [nvarchar](15) NULL,
	[PART_NO] [nvarchar](16) NULL,
	[PART_NO_DESC] [nvarchar](30) NULL,
	[SUPPLIER_ID] [nvarchar](12) NULL,
	[PRODUCT_CODE] [nvarchar](8) NULL,
	[ORDER_THICKNESS] [nvarchar](16) NULL,
	[ORDER_THICKNESS_UOM] [nvarchar](5) NULL,
	[ORDER_WIDTH] [nvarchar](16) NULL,
	[ORDER_WIDTH_UOM] [nvarchar](5) NULL,
	[ORDER_LENGTH] [nvarchar](16) NULL,
	[ORDER_LENGTH_UOM] [nvarchar](5) NULL,
	[METRIC_THICKNESS] [nvarchar](16) NULL,
	[METRIC_THICKNESS_UOM] [nvarchar](5) NULL,
	[METRIC_WIDTH] [nvarchar](16) NULL,
	[METRIC_WIDTH_UOM] [nvarchar](5) NULL,
	[METRIC_LENGTH] [nvarchar](16) NULL,
	[METRIC_LENGTH_UOM] [nvarchar](5) NULL,
	[MODIFIED_BY] [nvarchar](25) NULL,
	[DATE_TIMESTAMP] [datetime] NULL,
	[ACKR_REQ] [nvarchar](1) NULL,
	[PROCESSED_IND] [nvarchar](1) NULL,
	[CUST_PART_NO] [nvarchar](32) NULL,
	[CUST_PART_DESC] [nvarchar](32) NULL,
	[CUST_SPEC] [nvarchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MILL_TRANS_IN_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MILL_TRANS_IN_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[SENDER_QUAL] [nvarchar](2) NULL,
	[SENDER_ID] [nvarchar](22) NULL,
	[RECEIVER_QUAL] [nvarchar](2) NULL,
	[RECEIVER_ID] [nvarchar](22) NULL,
	[TRANSACTION_TYPE] [nvarchar](5) NULL,
	[ACKNOWLEDGEMENT_CODE] [nvarchar](5) NULL,
	[APPLICATION] [nvarchar](20) NULL,
	[MODIFIED_BY] [nvarchar](25) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PREQ_HEAD_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREQ_HEAD_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[ENTRY_DATE] [datetime] NULL,
	[ORDER_RECEIVE_DATE] [datetime] NULL,
	[START_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
	[STATUS] [nvarchar](10) NULL,
	[TRACKSYS_PREQ_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PREQ_REV_NUM] [numeric](3, 0) NULL,
	[FINANSYS_VENDOR_KEY] [nvarchar](12) NULL,
	[PREQ_CREATED_BY] [nvarchar](15) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PREQ_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREQ_LINE_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[LINE_NUMBER] [numeric](3, 0) NULL,
	[QUANTITY] [numeric](12, 3) NULL,
	[STATUS] [nvarchar](10) NULL,
	[DUE_DATE] [datetime] NULL,
	[PRICE_UMCODE] [nvarchar](8) NULL,
	[PROCESSING_CHARGE] [numeric](8, 4) NULL,
	[STORAGE_IN_CHARGE] [numeric](8, 4) NULL,
	[STORAGE_OUT_CHARGE] [numeric](8, 4) NULL,
	[STORAGE_DAY_CHARGE] [numeric](8, 4) NULL,
	[STORAGE_FREE_DAYS] [numeric](4, 0) NULL,
	[MISC_CHARGE] [numeric](8, 4) NULL,
	[STORAGE_EXPECTED_DAYS] [numeric](4, 0) NULL,
	[UNIT_COST] [numeric](8, 4) NULL,
	[EXTENDED_COST] [numeric](11, 2) NULL,
	[SPECIAL_INSTR_LINE_1] [nvarchar](50) NULL,
	[SPECIAL_INSTR_LINE_2] [nvarchar](50) NULL,
	[SPECIAL_INSTR_LINE_3] [nvarchar](50) NULL,
	[TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[FINANSYS_BILLTO_KEY] [nvarchar](10) NULL,
	[FINANSYS_SHIPTO_KEY] [nvarchar](10) NULL,
	[GL_ACCOUNT_NUMBER] [nvarchar](20) NULL,
	[MATERIAL_CHARGE] [numeric](8, 4) NULL,
	[FREIGHT1_CHARGE] [numeric](8, 4) NULL,
	[FREIGHT2_CHARGE] [numeric](8, 4) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PREQ_RESP_HEAD_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREQ_RESP_HEAD_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_PREQ_NUMBER] [numeric](7, 0) NULL,
	[FINANSYS_PREQ_NUMBER] [nvarchar](10) NULL,
	[TRACKSYS_PREQ_REV_NUM] [numeric](3, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PREQ_RESP_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREQ_RESP_LINE_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[PREQ_LINE_NUMBER] [numeric](3, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[FINANSYS_PO_NUMBER] [nvarchar](10) NULL,
	[PO_LINE_NUMBER] [numeric](3, 0) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SALESORD_HEAD_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALESORD_HEAD_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_SALESORD_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_SALESORD_REVISION] [numeric](3, 0) NULL,
	[ENTRY_DATE] [datetime] NULL,
	[ORDER_TYPE] [nvarchar](10) NULL,
	[CUSTOMER_CORP_DUNS] [nvarchar](9) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[HOLD_CODE] [nvarchar](10) NULL,
	[HOLD_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[HOLD_DATE] [datetime] NULL,
	[ORDER_NOTE_1] [nvarchar](100) NULL,
	[ORDER_NOTE_2] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SALESORD_LINE_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALESORD_LINE_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[LINE_NUMBER] [numeric](3, 0) NULL,
	[STATUS_CODE] [nvarchar](10) NULL,
	[TRACKSYS_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_PART_REVISION] [numeric](3, 0) NULL,
	[PART_COIL_ID_PREF] [numeric](6, 2) NULL,
	[PART_COIL_ID_MIN] [numeric](6, 2) NULL,
	[PART_COIL_OD_MIN] [numeric](6, 2) NULL,
	[PART_COIL_OD_MAX] [numeric](6, 2) NULL,
	[PART_WEIGHT_PREFERRED] [numeric](5, 0) NULL,
	[PART_WEIGHT_MIN] [numeric](5, 0) NULL,
	[PART_WEIGHT_MAX] [numeric](5, 0) NULL,
	[PART_WEIGHT_MAX_PACKAGE] [numeric](5, 0) NULL,
	[PART_PACKAGING_CODE] [nvarchar](8) NULL,
	[PART_MARKING_CODE] [nvarchar](8) NULL,
	[PART_LOADING_CODE] [nvarchar](8) NULL,
	[ACKNOWLEDGEMENT_DATE] [datetime] NULL,
	[START_DATE] [datetime] NULL,
	[END_DATE] [datetime] NULL,
	[DUE_DATE] [datetime] NULL,
	[MEASUREMENT_SYSTEM_CODE] [nvarchar](1) NULL,
	[QUANTITY] [numeric](9, 0) NULL,
	[QUANTITY_UM] [nvarchar](8) NULL,
	[QUANTITY_SHIPPED] [numeric](11, 0) NULL,
	[CUST_SHIP_MODE_CODE] [nvarchar](10) NULL,
	[CUST_FREIGHT_PAYMENT] [nvarchar](10) NULL,
	[CUST_PREFERRED_CARRIER] [nvarchar](20) NULL,
	[CUST_FREIGHT_CONTRACT] [nvarchar](18) NULL,
	[CUST_DELIVERY_ROUTE] [nvarchar](35) NULL,
	[CUST_RECEIVING_HOURS] [nvarchar](15) NULL,
	[SHIPPING_NOTE_1] [nvarchar](100) NULL,
	[SHIPPING_NOTE_2] [nvarchar](100) NULL,
	[SHIPPING_NOTE_3] [nvarchar](100) NULL,
	[SHIPPING_NOTE_4] [nvarchar](100) NULL,
	[PPOOC_COMMENT] [nvarchar](16) NULL,
	[CUST_PO_NUMBER] [nvarchar](10) NULL,
	[CUST_PO_DATE] [datetime] NULL,
	[CONTRACT_NUMBER] [nvarchar](16) NULL,
	[CUSTOMER_PLANT_DUNS] [nvarchar](9) NULL,
	[PLANT_BILL_TO_RECORD_KEY] [nvarchar](10) NULL,
	[PLANT_SHIP_TO_RECORD_KEY] [nvarchar](10) NULL,
	[PART_COIL_ID_MAX] [numeric](6, 2) NULL,
	[HOLD_CODE] [nvarchar](10) NULL,
	[HOLD_ACCOUNT_LOGIN] [nvarchar](15) NULL,
	[HOLD_DATE] [datetime] NULL,
	[PRICE_RAW_MATERIAL] [numeric](9, 4) NULL,
	[PRICE_RAW_MATERIAL_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_PROC_1] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_1] [nvarchar](100) NULL,
	[PRICE_PROCESSING_1] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_1] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_1] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_2] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_2] [nvarchar](100) NULL,
	[PRICE_PROCESSING_2] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_2] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_2] [numeric](6, 2) NULL,
	[PRICE_FREIGHT_TO_PROC_3] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_DESC_3] [nvarchar](100) NULL,
	[PRICE_PROCESSING_3] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_DESC_3] [nvarchar](100) NULL,
	[PRICE_YIELD_LOSS_PERCENT_3] [numeric](6, 2) NULL,
	[PRICE_PACKAGING] [numeric](9, 4) NULL,
	[PRICE_PACKAGING_DESC] [nvarchar](100) NULL,
	[PRICE_STORAGE_HANDLING] [numeric](9, 4) NULL,
	[PRICE_STORAGE_HANDLING_DESC] [nvarchar](100) NULL,
	[PRICE_FREIGHT_TO_CUST] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_CUST_DESC] [nvarchar](100) NULL,
	[PRICE_ADMIN] [numeric](9, 4) NULL,
	[PRICE_ADMIN_DESC] [nvarchar](100) NULL,
	[PRICE_UOM] [nvarchar](3) NULL,
	[PRICE_GROSS_UNIT] [numeric](9, 4) NULL,
	[PRICE_CWT] [numeric](9, 2) NULL,
	[PRICE_RAW_MATERIAL_CWT] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_1_CWT] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_1_CWT] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_2_CWT] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_2_CWT] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_PROC_3_CWT] [numeric](9, 4) NULL,
	[PRICE_PROCESSING_3_CWT] [numeric](9, 4) NULL,
	[PRICE_PACKAGING_CWT] [numeric](9, 4) NULL,
	[PRICE_STORAGE_HANDLING_CWT] [numeric](9, 4) NULL,
	[PRICE_FREIGHT_TO_CUST_CWT] [numeric](9, 4) NULL,
	[PRICE_ADMIN_CWT] [numeric](9, 4) NULL,
	[EXCEPTION_PRICING_FLAG] [nvarchar](1) NULL,
	[REF_CODE] [nvarchar](12) NULL,
	[CUSTOMER_PO] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SREQ_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SREQ_TX](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_STEEL_REQN_NUMBER] [numeric](7, 0) NULL,
	[MILL_ORG_CODE] [nvarchar](10) NULL,
	[TRACKSYS_SALESORD_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_SALESORD_REVISION] [numeric](3, 0) NULL,
	[SALESORD_LINE_NUMBER] [numeric](3, 0) NULL,
	[RESERVED_MILL_ORDER_NO] [nvarchar](12) NULL,
	[RESERVED_MILL_ORDER_LINE] [nvarchar](4) NULL,
	[CUSTOMER_PURCHASE_ORDER] [nvarchar](10) NULL,
	[CUSTOMER_PO_LINE] [nvarchar](4) NULL,
	[CUSTOMER_PO_DATE] [datetime] NULL,
	[BILLTO_RECORD_KEY] [nvarchar](10) NULL,
	[SHIPTO_RECORD_KEY] [nvarchar](10) NULL,
	[VENDOR_RECORD_KEY] [nvarchar](12) NULL,
	[FINANSYS_PO_NUMBER] [nvarchar](10) NULL,
	[PO_LINE_NUMBER] [numeric](3, 0) NULL,
	[VENDOR_PLANT_DUNS] [nvarchar](9) NULL,
	[SHIPTO_NAME] [nvarchar](50) NULL,
	[SHIPTO_ADDR_LINE_1] [nvarchar](32) NULL,
	[SHIPTO_ADDR_LINE_2] [nvarchar](32) NULL,
	[SHIPTO_CITY_TEXT] [nvarchar](32) NULL,
	[SHIPTO_REGION_TEXT] [nvarchar](32) NULL,
	[SHIPTO_POSTAL_CODE] [nvarchar](10) NULL,
	[SHIPTO_COUNTRY_TEXT] [nvarchar](32) NULL,
	[TRACKSYS_FINISHED_PART_NUMBER] [numeric](7, 0) NULL,
	[TRACKSYS_FINISHED_PART_REVISIO] [numeric](3, 0) NULL,
	[CUST_PART_NUMBER] [nvarchar](32) NULL,
	[CUST_PART_DESCRIPTION] [nvarchar](32) NULL,
	[CUST_END_USE] [nvarchar](32) NULL,
	[MIPS_SUBPRODUCT] [nvarchar](20) NULL,
	[MILLSYS_PART_NUMBER] [nvarchar](30) NULL,
	[MILL_PART_GAUGE] [numeric](11, 4) NULL,
	[MILL_GAUGE_TYPE] [nvarchar](3) NULL,
	[MILL_PART_WIDTH] [numeric](11, 4) NULL,
	[ENTRY_DATE] [datetime] NULL,
	[REQUESTED_WEIGHT] [numeric](9, 0) NULL,
	[REQUESTED_SHIP_DATE] [datetime] NULL,
	[REQUESTED_MILL_DATE] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRANSACTION_INBOUND]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANSACTION_INBOUND](
	[TRACKSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[ENTITY_TYPE_CODE] [nvarchar](20) NOT NULL,
	[TRANSACTION_TYPE_CODE] [nvarchar](6) NOT NULL,
	[SUBMISSION_DATETIME] [datetime] NOT NULL,
	[ENTITY_CODE] [nvarchar](5) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRANSACTION_OUTBOUND]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANSACTION_OUTBOUND](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[ENTITY_TYPE_CODE] [nvarchar](30) NOT NULL,
	[TRANSACTION_TYPE_CODE] [nvarchar](6) NOT NULL,
	[SUBMISSION_DATETIME] [datetime] NOT NULL,
	[ENTITY_CODE] [nvarchar](5) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VENDOR_MASTER_TX]    Script Date: 8/23/2016 11:50:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENDOR_MASTER_TX](
	[FINANSYS_TRANSACTION_SKEY] [numeric](20, 0) NOT NULL,
	[FINANCIAL_ORG_CODE] [nvarchar](10) NULL,
	[VENDOR_RECORD_KEY] [nvarchar](12) NULL,
	[VENDOR_TYPE_CODE] [nchar](1) NULL,
	[NAME] [nvarchar](50) NULL,
	[NAME_2] [nvarchar](50) NULL,
	[VENDOR_CORP_DUNS] [nvarchar](9) NULL,
	[VENDOR_PLANT_DUNS] [nvarchar](9) NULL,
	[REMIT_TO_FLAG] [nchar](1) NULL,
	[REMIT_TO_VENDOR_RECORD_KEY] [nvarchar](12) NULL,
	[MONTHLY_VOLUME_TONS] [numeric](6, 0) NULL,
	[FREIGHT_TERMS_CODE] [nvarchar](8) NULL,
	[FREIGHT_TERMS_TEXT] [nvarchar](35) NULL,
	[PAYMENT_TERMS_CODE] [nvarchar](15) NULL,
	[PAYMENT_TERMS_TEXT] [nvarchar](35) NULL,
	[STOP_PAYMENT_FLAG] [nchar](1) NULL,
	[SHIP_MODE_CODE] [nvarchar](10) NULL,
	[SHIP_MODE_TEXT] [nvarchar](35) NULL,
	[APPOINTMENT_REQUIRED_FLAG] [nchar](1) NULL,
	[PO_VIA_EDI_FLAG] [nchar](1) NULL,
	[PO_VIA_MAIL_FLAG] [nchar](1) NULL,
	[PO_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[PO_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[TEST_REPORT_VIA_EDI_FLAG] [nchar](1) NULL,
	[TEST_REPORT_VIA_MAIL_FLAG] [nchar](1) NULL,
	[TEST_REPORT_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[TEST_REPORT_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[MATERIAL_REL_VIA_EDI_FLAG] [nchar](1) NULL,
	[MATERIAL_REL_VIA_MAIL_FLAG] [nchar](1) NULL,
	[MATERIAL_REL_VIA_EMAIL_FLAG] [nchar](1) NULL,
	[MATERIAL_REL_VIA_FAX_FREQ_CODE] [nvarchar](6) NULL,
	[RECEIVING_DAYS] [nvarchar](6) NULL,
	[RECEIVING_START_TIME] [numeric](4, 0) NULL,
	[RECEIVING_END_TIME] [numeric](4, 0) NULL,
	[MAX_LOADS_PER_DAY] [numeric](2, 0) NULL,
	[RAIL_CONTRACT_NUMBER] [nvarchar](10) NULL,
	[RAIL_ROUTING_CODE] [nvarchar](6) NULL,
	[RAIL_ROUTING_TEXT] [nvarchar](35) NULL,
	[PACKING_CODE] [nvarchar](6) NULL,
	[PACKING_TEXT] [nvarchar](35) NULL,
	[LOADING_CODE] [nvarchar](6) NULL,
	[LOADING_TEXT] [nvarchar](35) NULL
) ON [PRIMARY]

GO
