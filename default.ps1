properties {
    $buildDir = ".\build"
    $outputDir = $buildDir + "\lib\" + $framework
    $out = $outputDir + "\SgmlReaderDll.dll"
    $nunitDir = (gci -fi NUnit* .\packages).FullName
    $nunit = (gci $nunitDir\Tools\nunit-console.exe)
}

task default -depends Compile, Clean

task Init -depends Clean {
    mkdir $outputDir | out-null
}

task Compile -depends Init { 
    $sources = gci ".\sgmlreaderdll" -r -fi *.cs |% { $_.FullName }
    csc /target:library /out:$out $sources /keyfile:.\sgmlreaderdll\sgmlreader.snk /resource:".\SgmlReader\Html.dtd,SgmlReaderDll.Html.dtd"
}

task Test -depends Compile {
    . $nunit $out
}

task Clean { 
    if (test-path $outputDir) { 
        ri -r -fo $outputDir 
    }
}
