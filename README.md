DocXToMarkdown
==============

A proof-on-concept app that converts DocX documents to markdown format.
Build upon an excellent library: [DocX](http://docx.codeplex.com). The lib included in repo had some little modification (built with the latest
source). So at the moment it couldn't be replaced. 

# Instalation #

At the moment it needs to be compiled from sources.

# Usage #

The conversion process contains two phases:

### Analyze phase ###

   You must run **DocXToMarkdown.exe** with the */analyze* parameter,
eg:

`DocXToMarkdown.exe /analyze CV.docx`

This call will produce the **CV.json** file, which contains all the
different styles that document contains. This is the simple JSON object,
where keys are the styles from document, and values are markdown
elements, that the concrete style will be convert to.

The file looks like this (keys are from polish version of Word 2013):

```json
{  
    "Nagwek1": "Header1",  
    "Nagwek2": "Header2",  
    "ordered_lista1": "OrderedList",  
}  
```

Avaliable converters: 

 * Header1
 * Header2
 * Header3
 * Header4
 * Header5
 * Header6
 * P
 * OrderedList
 * UnorderedList

Application will try do guess which style should be assigned to which
converter, based on number and type, but You need to check its guess.

When converters are assigned, the next phase is actual convert.

### Convert phase ###

   You must run **DocXToMarkdown.exe** with the */convert* parameter,
eg:

`DocXToMarkdown.exe /convert CV.docx`

It will produce multiple files:

 * CV.md - actual markdown code
 * CV\_images/\*.jpg - directory that contains images

Thats all :)
