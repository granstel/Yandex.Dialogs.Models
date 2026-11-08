param(
    [Parameter(Mandatory)]
    [string]$Tag
)

$number = '(?:0|[1-9][0-9]*)'
$prerelease = "(?:$number|[0-9]*[A-Za-z-][0-9A-Za-z-]*)"
$build = '[0-9A-Za-z-]+'
$semver = "$number\.$number\.$number(?:-$prerelease(?:\.$prerelease)*)?(?:\+$build(?:\.$build)*)?"

if ($Tag -cmatch "\Av?($semver)\z") {
    return $Matches[1]
}

throw 'Release tag must be a SemVer version with an optional lowercase v prefix.'
