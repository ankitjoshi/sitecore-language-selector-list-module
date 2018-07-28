# sitecore-language-selector-list-module-

We sometime come across the requirements where we have to select from the available languages versions which have been added for the context site.

For example- there could be total 10 languages under system languages folder and out of 10 say only 3 languages has been added to specific site.

For instance we work on any module where we need to select only few languages from the total languages available for that site, we don’t have any specific field type that can populate languages, one example could be language switcher where content authors wants to show only 2 languages to end users even for that site 3 language versions exists, and the same scenarios for multiple site under same sitecore instance.

This modules helps to solve the same issue- and populates dynamically all language versions available for that site, it doesn’t populates all the languages from system languages instead take only those language versions which has been added as part of home page, this assumes that language versions that has been added to home page will be available to other inner pages as well.

In case of multisite setup, this field has taken habitat site as a reference and expects rootPath value to be unique for all Sites added to the instance.

RELEASE NOTES
This package installs the following to your Sitecore instance:- 

•	\bin\ Sitecore.SharedSource.LanguageSelectorList.dll
•	\ App_Config\Include\Foundation\ Sitecore.SharedSource.CustomFields.LanguageSelectorList.config
And adds the following item to your Core DB to add the new custom field to your database: - /sitecore/system/Field types/Custom Field Types/Language Selector List 
After installation, “Language Selector List” will be available as an option in the Sitecore Field Types (Custom Field Types) - while adding a field to any template. 
The source of this field type should be set to “/sitecore/system/Languages”.



