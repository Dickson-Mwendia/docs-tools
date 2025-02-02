﻿namespace Quest2GitHub.Options;

public sealed record class ApiKeys
{
    /// <summary>
    /// The GitHub token (or <c>${{ secrets.GITHUB_TOKEN }}</c>) used to read issues and update labels with.
    /// Consuming workflows should specify:
    /// <code>
    /// jobs:
    ///   build:
    ///   runs-on: ubuntu-latest
    ///   
    ///   permissions:    # Define permissions
    ///     issues: write # Enable reading issues, and applying labels
    /// </code>
    /// For more information, see <a href="https://docs.github.com/actions/using-workflows/workflow-syntax-for-github-actions#jobsjob_idpermissions"></a>.
    /// </summary>
    /// <remarks>
    /// Assign this from an environment variable with the following key, <c>ImportOptions__ApiKeys__GitHubToken</c>:
    /// <code>
    /// env:
    ///   ImportOptions__ApiKeys__GitHubToken: ${{ secrets.GITHUB_TOKEN }}
    /// </code>
    /// </remarks>
    public required string GitHubToken { get; init; }

    /// <summary>
    /// The Microsoft Open Source Programs Office API key.
    /// </summary>
    /// <remarks>
    /// Assign this from an environment variable with the following key, <c>ImportOptions__ApiKeys__OSPOKey</c>:
    /// <code>
    /// env:
    ///   ImportOptions__ApiKeys__OSPOKey: ${{ secrets.OSPO_API_KEY }}
    /// </code>
    /// </remarks>
    public required string OSPOKey { get; init; }

    /// <summary>
    /// The Azure DevOps API key.
    /// </summary>
    /// <remarks>
    /// Assign this from an environment variable with the following key, <c>ImportOptions__ApiKeys__QuestKey</c>:
    /// <code>
    /// env:
    ///   ImportOptions__ApiKeys__QuestKey: ${{ secrets.QUEST_API_KEY }}
    /// </code>
    /// </remarks>
    public required string QuestKey { get; init; }
}